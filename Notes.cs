using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_des_notes
{
    internal class Notes
    {
        private int numeroEtudiant;
        private int numeroCours;
        private double note;

        public Notes(int numeroEtudiant, int numeroCours, double note)
        {
            this.numeroEtudiant = numeroEtudiant;
            this.numeroCours = numeroCours;
            this.note = note;
        }

        public int NumeroEtudiant 
        { 
            get => numeroEtudiant; 
            set => numeroEtudiant = value; 
        }
        public int NumeroCours 
        { 
            get => numeroCours; 
            set => numeroCours = value; 
        }
        public double Note 
        { 
            get => note; 
            set => note = value; 
        }

        public static void ajouterNote(List<Notes> notes)
        {
            double note;
            int numeroEtudiant;
            int numeroCours;

            string numeroEtudiantSaisie;
            string numeroCoursSaisie;
            string noteSaisie;

            bool reponse1=false;
            bool reponse2=false;
            bool reponse3=false;
            do
            {
                Console.WriteLine("Entrer le numero de l'etudiant: ");
                numeroEtudiantSaisie = Console.ReadLine();

                Console.WriteLine("Entrer le numero du cours: ");
                numeroCoursSaisie = Console.ReadLine();

                Console.WriteLine("Entrer la note: ");
                noteSaisie = Console.ReadLine();

                reponse1=int.TryParse(numeroEtudiantSaisie, out numeroEtudiant);
                reponse2=int.TryParse(numeroCoursSaisie, out numeroCours);
                reponse3=double.TryParse(noteSaisie,out note);

                if (!reponse1 || !reponse2 || !reponse3 )
                {
                    Console.WriteLine("Les valeur saisie ne sont pas correct, veuillez mettre les valeurs corrects");
                    Console.WriteLine();
                }

            } while (!reponse1 || !reponse2 || !reponse3);

            Notes nouvelNote = new Notes(numeroEtudiant, numeroCours, note);
            notes.Add(nouvelNote);

            Console.WriteLine("Noter ajoutée avec succès");
        }

        public override string ToString()
        {
            return $@"Cours:{NumeroCours}, Note:{Note}";
        }
    }
}
