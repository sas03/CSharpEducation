using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEducatif.Classes
{
    public class Eleve
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public DateTime dateDeNaissance { get; set; }
        public int moyenne { get; set; }
        public List<Notes> data { get; set; }
        public List<Eleve> eleves { get; set; }
        public void listeEleve()
        {
            foreach (Eleve e in eleves)
            {
                Console.WriteLine(e.nom);
            }
        }
        public void ajoutEleve(string nomE, string prenomE, DateTime dateN)
        {
            eleves.Add(new Eleve()
            {
                nom = nomE,
                prenom = prenomE,
                dateDeNaissance = dateN
            });
        }
    }

    public class Notes
    {
        public float note { get; set; }
        public string appreciation { get; set; }
    }
}

