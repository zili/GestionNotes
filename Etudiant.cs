namespace GestionNotes;

/// <summary>
/// Représente un étudiant et ses notes (encapsulation : la liste n'est pas modifiable de l'extérieur).
/// </summary>
public class Etudiant
{
    public const double NoteMin = 0;
    public const double NoteMax = 20;

    private readonly List<double> _notes = new();

    public string Nom { get; }
    public IReadOnlyList<double> Notes => _notes;
    public int Rang { get; set; }

    public Etudiant(string nom)
    {
        if (string.IsNullOrWhiteSpace(nom))
            throw new ArgumentException("Le nom ne peut pas être vide.", nameof(nom));
        Nom = nom.Trim();
    }

    public void AjouterNote(double note)
    {
        if (note < NoteMin || note > NoteMax)
            throw new ArgumentOutOfRangeException(nameof(note), $"La note doit être comprise entre {NoteMin} et {NoteMax}.");
        _notes.Add(note);
    }

    /// <summary>Moyenne des notes, ou null si aucune note (évite de classer un étudiant à 0 par erreur).</summary>
    public double? Moyenne => _notes.Count == 0 ? null : _notes.Average();

    public override string ToString()
    {
        string moy = Moyenne is double m ? m.ToString("0.00") : "  -  ";
        string notes = _notes.Count == 0 ? "(aucune note)" : string.Join(" ; ", _notes.Select(n => n.ToString("0.##")));
        string rang = Rang > 0 ? Rang.ToString() : "-";
        return $"{rang,4}  {Nom,-15} {moy,7}   {notes}";
    }
}
