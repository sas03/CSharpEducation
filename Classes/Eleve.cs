//using Newtonsoft.Json;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SystemEducatif.Classes
{
    public class Eleve
    {
        public static int incrementE = 0;
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public DateTime dateDeNaissance { get; set; }
        //public int moyenne { get; set; }

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
                Console.WriteLine(e.id + "- " + e.nom + " " + e.prenom + " " + e.dateDeNaissance.ToString("yyyy-MM-dd HH:mm:ss"));
                if(e.data.Count != 0)
                {
                    Console.WriteLine("Notes");
                    foreach(Notes n in e.data)
                    {
                        Console.WriteLine("Cours: " + n.cours_id.nom + " Note: " + n.note + " Appreciation: " + n.appreciation);
                    }
                }
            }
            Console.ReadLine();
        }
        public static void ajoutEleve(string nomE, string prenomE, string dateN)
        {
            if (DateTime.TryParse(dateN, out DateTime date))
            {
                Eleve newE = new Eleve()
                {
                    id = ++incrementE,
                    nom = nomE,
                    prenom = prenomE,
                    dateDeNaissance = date
                };
                eleves.Add(newE);

                //serialize l'objet en une chaine de charactères JSON(Json string)
                string json = JsonSerializer.Serialize(eleves);

                //écrire la chaine JSON string en un fichier
                File.WriteAllText("education.json", json);

                Console.WriteLine("élève ajouté avec succès");
            }
            else
            {
                Console.WriteLine("Wrong Date Format");
            }
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
        public static void ConsultEleve(int id)
        {
            Eleve eleveConsulte = eleves.FirstOrDefault(e => e.id == id);
            if (eleveConsulte != null)
            {
                Console.WriteLine(eleveConsulte.id + "- " + eleveConsulte.nom + " " + eleveConsulte.prenom + " " + eleveConsulte.dateDeNaissance.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("L'élève avec l'id " + id + " n'existe pas.");
                Console.ReadLine();
            }
        }
        public void ajoutNotes()
        {
            Console.WriteLine("Id du cours: ");
            int cID = Convert.ToInt32(Console.ReadLine());
            Cours cours = Cours.cours.Find(c => c.id == cID);
            if (cours != null)
            {
                Console.WriteLine("Note: ");
                double n = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Voulez-vous ajouter une appréciation ? (Oui/Non)");
                string answer = Console.ReadLine();
                if (answer == "Oui")
                {
                    Console.WriteLine("Entrez votre appréciation: ");
                    string appreciate = Console.ReadLine();
                    data.Add(new Notes()
                    {
                        cours_id = cours,
                        note = n,
                        appreciation = appreciate

                    });
                }
                else if (answer == "Non")
                {
                    data.Add(new Notes()
                    {
                        cours_id = cours,
                        note = n,
                        appreciation = null
                    });
                }
                else
                {
                    Console.WriteLine("Wrong choix");
                }
            }
            else
            {
                Console.WriteLine("Il n'existe pas de cours avec cet identifiant");
            }
        }
    }

    public class Notes
    {
        public int id { get; set; }
        public Cours cours_id { get; set; }
        //public Eleve eleve_id { get; set; }
        public double note { get; set; }
        public string appreciation { get; set; }
    }
}

