namespace GestionNotes
{
    public class Classe
    {
        private Etudiant[] etudiants;

        public Classe(int nombre)
        {
            etudiants = new Etudiant[nombre];
        }

        public int Nombre
        {
            get { return etudiants.Length; }
        }

        public void AjouterEtudiant(int index, Etudiant etudiant)
        {
            etudiants[index] = etudiant;
        }

        public Etudiant GetEtudiant(int index)
        {
            return etudiants[index];
        }

        public void Classer()
        {
            for (int i = 0; i < etudiants.Length - 1; i++)
            {
                for (int j = 0; j < etudiants.Length - 1 - i; j++)
                {
                    if (etudiants[j].CalculerMoyenne() < etudiants[j + 1].CalculerMoyenne())
                    {
                        Etudiant temp = etudiants[j];
                        etudiants[j] = etudiants[j + 1];
                        etudiants[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < etudiants.Length; i++)
            {
                if (i > 0 && etudiants[i].CalculerMoyenne() == etudiants[i - 1].CalculerMoyenne())
                {
                    etudiants[i].Rang = etudiants[i - 1].Rang;
                }
                else
                {
                    etudiants[i].Rang = i + 1;
                }
            }
        }

        public void Afficher()
        {
            for (int i = 0; i < etudiants.Length; i++)
            {
                etudiants[i].Afficher();
            }
        }
    }
}
