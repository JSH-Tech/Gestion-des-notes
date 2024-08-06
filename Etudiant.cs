using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_des_notes
{
    internal class Etudiant
    {
        private static int generateur = 0; // variable statique pour générer les numéros d'étudiant

        //Les preopriete de la classe etudiant
        private int numeroEtudiant;
        private string nom;
        private string prenom;
        List<Notes> listNotes;

        public Etudiant(string nom, string prenom)
        {
            this.numeroEtudiant = ++generateur;
            this.nom = nom;
            this.prenom = prenom;
            this.listNotes = new List<Notes>();
        }

        public int NumeroEtudiant
        { 
            get => numeroEtudiant; 

            private set => numeroEtudiant = value;
        }
        public string Nom 
        { 
            get => nom; 
            set => nom = value;
        }
        public string Prenom
        { 
            get => prenom; 
            set => prenom = value; 
        }
        internal List<Notes> ListNotes
        { 
            get => listNotes; 
            set => listNotes = value; 
        }

        public static void ajouterEtudiant(List<Etudiant> etudiants)
        {
            string nom=null;
            string prenom=null;
            do
            {
                Console.WriteLine("Entrer le nom de l'étudiant: ");
                nom = Console.ReadLine();

                Console.WriteLine("Entrer le prenom de l'étudiant: ");
                prenom = Console.ReadLine();

                if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom))
                {
                    Console.WriteLine("Le nom ou le prenom ne peut etre null");
                    Console.WriteLine();
                }

            } while (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom));

            Etudiant nouveauEtudiant=new Etudiant(nom, prenom);
            etudiants.Add(nouveauEtudiant);
            Notes.ajouterNote(nouveauEtudiant.ListNotes);
            EnregistrerEtudiant(nouveauEtudiant);
            Console.WriteLine("Etudiant ajouté avec succès");
        }

        public static void EnregistrerEtudiant(Etudiant etudiant)
        {
            string filePath = $"{etudiant.NumeroEtudiant}.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(etudiant.ToString());
                foreach (var note in etudiant.ListNotes)
                {
                    writer.WriteLine(note.ToString());
                }
            }
            Console.WriteLine($"Les informations de l'étudiant {etudiant.NumeroEtudiant} ont été enregistrées dans {filePath}");
        }

        public static Etudiant ChargerEtudiant(int numeroEtudiant)
        {
            string filePath = $"{numeroEtudiant}.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Le fichier {filePath} n'existe pas.");
                return null;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] lignes = File.ReadAllLines(filePath);
                string[] etudiantInfo = lignes[0].Split(',');
                string nom = etudiantInfo[1].Split(':')[1].Trim();
                string prenom = etudiantInfo[2].Split(':')[1].Trim();

                Etudiant etudiant = new Etudiant(nom, prenom);
                for (int i = 1; i < lignes.Length; i++)
                {
                    string[] noteInfo = lignes[i].Split(',');
                    int numeroCours = int.Parse(noteInfo[1].Split(':')[1].Trim());
                    double note = double.Parse(noteInfo[2].Split(':')[1].Trim());
                    etudiant.ListNotes.Add(new Notes(numeroEtudiant, numeroCours, note));
                }
                return etudiant;
            }
        }

        public override string ToString() {
            return $@"Etudiant: {NumeroEtudiant} {Nom} {Prenom} .";
        }
    }
}
