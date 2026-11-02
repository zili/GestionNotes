using System;

namespace GestionNotes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Classe classe = new Classe(4);

            for (int i = 0; i < classe.Nombre; i++)
            {
                Console.Write("Nom de l'etudiant " + (i + 1) + " : ");
                string nom = Console.ReadLine();
                classe.AjouterEtudiant(i, new Etudiant(nom));
            }

            for (int i = 0; i < classe.Nombre; i++)
            {
                Etudiant etudiant = classe.GetEtudiant(i);
                Console.WriteLine();
                Console.WriteLine("Notes de " + etudiant.Nom + " (laisser vide pour terminer) :");

                while (true)
                {
                    Console.Write("Note : ");
                    string saisie = Console.ReadLine();

                    if (string.IsNullOrEmpty(saisie))
                    {
                        break;
                    }

                    double note;
                    if (double.TryParse(saisie, out note) && note >= 0 && note <= 20)
                    {
                        etudiant.AjouterNote(note);
                    }
                    else
                    {
                        Console.WriteLine("Note invalide (entre 0 et 20).");
                    }
                }
            }

            classe.Classer();

            Console.WriteLine();
            Console.WriteLine("=== Classement ===");
            classe.Afficher();
        }
    }
}
