using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEducatif.Classes
{
    public class Cours
    {
        public int id { get; set; }
        public string nom { get; set; }
        public List<Cours> cours { get; set; }
        public void listeCours()
        {
            foreach (Cours c in cours)
            {
                Console.WriteLine(c.nom);
            }
        }
        public void ajoutCours(string nomC)
        {
            cours.Add(new Cours()
            {
                nom = nomC
            });
        }
    }
}
