using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_des_notes
{
    internal class Cours
    {
        private static int generateur = 0;
        //  Propriete de la classe cours
        private int numeroCours;
        private string codeCours;
        private string titreCours;

        public Cours( string codeCours, string titreCours)
        {
            this.numeroCours = ++generateur;
            this.codeCours = codeCours;
            this.titreCours = titreCours;
        }

        public int NumeroCours
        { 
            get => numeroCours; 
            private set => numeroCours = value; 
        }
        public string CodeCours 
        { 
            get => codeCours; 
            set => codeCours = value; 
        }
        public string TitreCours 
        { 
            get => titreCours; 
            set => titreCours = value; 
        }

        public static void ajouterCours(List<Cours> cours)
        {
            string codeCours = null;
            string titreCours = null;
            do
            {
                Console.WriteLine("Entrer le code du cours: ");
                codeCours = Console.ReadLine();

                Console.WriteLine("Entrer le titre du cours: ");
                titreCours = Console.ReadLine();

                if (string.IsNullOrEmpty(codeCours) || string.IsNullOrEmpty(titreCours))
                {
                    Console.WriteLine("Le code du cours ou le titre du cours ne peut etre null");
                    Console.WriteLine();
                }

            } while (string.IsNullOrEmpty(codeCours) || string.IsNullOrEmpty(titreCours));

            Cours nouveauCours = new Cours(codeCours, titreCours);
            cours.Add(nouveauCours);
            Console.WriteLine("Cours ajouté avec succès");
        }

        public override string ToString()
        {
            return $@"Cours: {NumeroCours} {CodeCours} {TitreCours}";
        }
    }
}
