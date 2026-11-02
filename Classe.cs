namespace GestionNotes;

/// <summary>
/// Regroupe les étudiants et porte la logique de classement.
/// </summary>
public class Classe
{
    private readonly List<Etudiant> _etudiants = new();

    public IReadOnlyList<Etudiant> Etudiants => _etudiants;

    public void AjouterEtudiant(Etudiant etudiant) => _etudiants.Add(etudiant);

    /// <summary>
    /// Calcule les rangs (classement "olympique" : ex æquo = même rang, le suivant saute).
    /// Les étudiants sans note sont placés en fin de liste, sans rang (0).
    /// </summary>
    public List<Etudiant> Classer()
    {
        var classes = _etudiants
            .Where(e => e.Moyenne.HasValue)
            .OrderByDescending(e => e.Moyenne)
            .ThenBy(e => e.Nom)
            .ToList();

        for (int i = 0; i < classes.Count; i++)
        {
            bool exAequo = i > 0 && Math.Abs(classes[i].Moyenne!.Value - classes[i - 1].Moyenne!.Value) < 1e-9;
            classes[i].Rang = exAequo ? classes[i - 1].Rang : i + 1;
        }

        var sansNote = _etudiants.Where(e => !e.Moyenne.HasValue).ToList();
        sansNote.ForEach(e => e.Rang = 0);

        return classes.Concat(sansNote).ToList();
    }
}
