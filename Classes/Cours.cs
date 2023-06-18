using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEducatif.Classes
{
    public class Cours
    {
        public static int incrementC = 0;
        public int id { get; set; }
        public string nom { get; set; }

        public static List<Cours> cours = new List<Cours>();

        /*public Cours() 
        {
            id = ++incrementC;
        }*/
        public static void listeCours()
        {
            Console.Clear();
            foreach (Cours c in cours)
            {
                Console.WriteLine(c.nom);
            }
            Console.ReadLine();
        }
        public static void ajoutCours(string nomC)
        {
            cours.Add(new Cours()
            {
                id = ++incrementC,
                nom = nomC
            });
        }
    }
}
