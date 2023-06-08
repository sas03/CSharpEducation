using SystemEducatif.Classes;

namespace SystemEducatif;

class Program {
    public static void Main(string[] args) {
        Console.WriteLine("Hello World");
        Eleve e = new Eleve();

        Cours c = new Cours();
        c.ajoutCours("CSharp");
    }
}