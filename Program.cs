using System.Globalization;
using GestionNotes;

const int NombreEtudiants = 4;
var classe = new Classe();

Console.WriteLine("=== Gestion des notes ===\n");

// 1. Saisie des étudiants
for (int i = 1; i <= NombreEtudiants; i++)
{
    while (true)
    {
        Console.Write($"Nom de l'étudiant {i} : ");
        try
        {
            classe.AjouterEtudiant(new Etudiant(Console.ReadLine() ?? ""));
            break;
        }
        catch (ArgumentException ex) { Console.WriteLine($"  ! {ex.Message}"); }
    }
}

// 2. Saisie des notes (nombre illimité, ligne vide pour terminer)
foreach (var etudiant in classe.Etudiants)
{
    Console.WriteLine($"\nNotes de {etudiant.Nom} (Entrée sur une ligne vide pour terminer) :");
    while (true)
    {
        Console.Write($"  Note n°{etudiant.Notes.Count + 1} : ");
        string? saisie = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(saisie)) break;

        // Accepte "12,5" et "12.5"
        if (!double.TryParse(saisie.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out double note))
        {
            Console.WriteLine("  ! Saisie invalide, entrez un nombre.");
            continue;
        }
        try { etudiant.AjouterNote(note); }
        catch (ArgumentOutOfRangeException) { Console.WriteLine($"  ! La note doit être entre {Etudiant.NoteMin} et {Etudiant.NoteMax}."); }
    }
}

// 3. Classement et affichage
Console.WriteLine("\n=== Classement ===");
Console.WriteLine($"{"Rang",4}  {"Nom",-15} {"Moyenne",7}   Notes");
Console.WriteLine(new string('-', 60));
foreach (var e in classe.Classer())
    Console.WriteLine(e);
