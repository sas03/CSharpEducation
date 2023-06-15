//using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEducatif.Classes
{
    public class Eleve
    {
        public static int incrementE = 0;
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public DateTime dateDeNaissance { get; set; }
        public int moyenne { get; set; }

        public List<Notes> data = new List<Notes>();
        
        public static List<Eleve> eleves = new List<Eleve>();
        /*public Eleve()
        {
            id = incrementE++;
        }*/
        public static void listeEleves()
        {
            Console.Clear();
            foreach (Eleve e in eleves)
            {
                Console.WriteLine(e.id + e.nom + e.prenom + e.dateDeNaissance.ToString("dd/MM/yyyy"));
            }
            Console.ReadLine();
        }
        public static void ajoutEleve(string nomE, string prenomE, DateTime dateN)
        {
            Eleve newE = new Eleve()
            {
                id = ++incrementE,
                nom = nomE,
                prenom = prenomE,
                dateDeNaissance = dateN
            };
            eleves.Add(newE);

            //serialize l'objet en une chaine de charactères JSON(Json string)
            string json = JsonSerializer.Serialize(eleves);

            //écrire la chaine JSON string en un fichier
            File.WriteAllText("education.json", json);

            Console.WriteLine("élève ajouté avec succès");
            Console.ReadLine();
        }
        public void readJson()
        {
            string json = File.ReadAllText("education.json");
            List<Eleve> eleves = JsonSerializer.Deserialize<List<Eleve>>(json);
            foreach(Eleve e in eleves)
            {
                Console.WriteLine(e.nom + e.prenom);
            }
            Console.ReadLine();
        }
        public void ConsultEleve(int id)
        {
            foreach(Eleve e in eleves)
            {
                if(e.id == id)
                {
                    Console.WriteLine(e.nom + e.prenom + e.dateDeNaissance.ToString("dd/MM/yyyy") + e.moyenne);
                }
            }
        }
        public void ajoutNotes(float noteT, string appreciate)
        {
            data.Add(new Notes()
            {
                note = noteT,
                appreciation = appreciate

            });
        }
    }

    public class Notes
    {
        public int id { get; set; }
        public int cours_id { get; set; }
        public int eleve_id { get; set; }
        public float note { get; set; }
        public string appreciation { get; set; }
    }
}

