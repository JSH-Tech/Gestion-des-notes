using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_des_notes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Etudiant> etudiants = new List<Etudiant>();
            List<Cours> cours = new List<Cours>();
            List<Notes> notes = new List<Notes>();

            while (true)
            {
                Console.WriteLine("1. Ajouter un étudiant");
                Console.WriteLine("2. Ajouter un cours");
                Console.WriteLine("3. Ajouter une note");
                Console.WriteLine("4. Afficher le relevé de notes d'un étudiant");
                Console.WriteLine("5. Quitter");

                int choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        Etudiant.ajouterEtudiant(etudiants);
                        break;
                    case 2:
                        Cours.ajouterCours(cours);
                        break;
                    case 3:
                        Notes.ajouterNote(notes);
                        break;
                    case 4:
                        Console.Write("Numéro d'étudiant: ");
                        int numeroEtudiant = int.Parse(Console.ReadLine());
                        Etudiant.ChargerEtudiant(numeroEtudiant);
                        break;
                    case 5:
                        return;
                }
            }
        }
    }
}
