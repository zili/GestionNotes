using System.Collections.Generic;

namespace GestionNotes
{
    public class Etudiant
    {
        private string nom;
        private List<double> notes;
        private int rang;

        public Etudiant(string nom)
        {
            this.nom = nom;
            this.notes = new List<double>();
        }

        public string Nom
        {
            get { return nom; }
        }

        public int Rang
        {
            get { return rang; }
            set { rang = value; }
        }

        public void AjouterNote(double note)
        {
            notes.Add(note);
        }

        public double CalculerMoyenne()
        {
            if (notes.Count == 0)
            {
                return 0;
            }

            double somme = 0;
            foreach (double note in notes)
            {
                somme += note;
            }
            return somme / notes.Count;
        }

        public void Afficher()
        {
            System.Console.Write(rang + " - " + nom + " | Notes : ");
            foreach (double note in notes)
            {
                System.Console.Write(note + " ");
            }
            System.Console.WriteLine("| Moyenne : " + CalculerMoyenne().ToString("0.00"));
        }
    }
}
