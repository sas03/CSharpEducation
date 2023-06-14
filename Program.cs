using SystemEducatif.Classes;

namespace SystemEducatif;

class Program {
    public static void MenuPrincipal()
    {
        string[] menuOptions = new string[] { "Eleves\t", "Cours\t" };
        int menuSelect = 0;

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("Bienvenue sur le Meilleur Système Educatif dans le monde !!!");
            Console.WriteLine("Bien vouloir sélectionner entre Eleves ou Cours");
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine((i == menuSelect ? "* " : "") + menuOptions[i] + (i == menuSelect ? "<--" : ""));
            }
            var keyPressed = Console.ReadKey();
            if(keyPressed.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
            {
                menuSelect++;
            }
            else if(keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            else if(keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelect)
                {
                    case 0:
                        ChoixEleve();
                        break;
                    case 1:
                        ChoixCours();
                        break;
                }
            }
        }        
    }
    public static void ChoixEleve()
    {
        Console.Clear();
        Console.WriteLine("Liste des élèves");
        Console.ReadLine();
    }
    public static void ChoixCours()
    {
        Console.Clear();
        Console.WriteLine("Liste des cours");
        Console.ReadLine();
    }

    public static void Main(string[] args) {
        //MenuPrincipal();
        Console.WriteLine("Hello World");
        Eleve e = new Eleve();
        e.ajoutEleve("Sumo", "Stephane", DateTime.Now);
        e.ajoutEleve("Zeff", "Sophie", DateTime.Now);
        e.ajoutEleve("Drake", "Stephane", DateTime.Now);
        e.ajoutEleve("Meister", "Sophie", DateTime.Now);
        e.listeEleves();

        Cours c = new Cours();
        c.ajoutCours("CSharp");
        c.listeCours();
    }
}