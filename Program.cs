using SystemEducatif.Classes;

namespace SystemEducatif;

class Program {
    public static void MenuPrincipal()
    {
        string[] menuOptions = new string[] { "Eleves\t", "Cours\t" };
        int menuSelect = 0;

        //loop infinie du code à l'intérieur jusqu'au "break/return" pour terminer le programme
        while (true)
        {
            Console.Clear();
            //Enlève la visibilité du curseur en console
            Console.CursorVisible = false;
            Console.WriteLine("Bienvenue sur le Meilleur Système Educatif dans le monde !!!\nBien vouloir sélectionner entre Eleves ou Cours");
            
            //boucle for autour de l'array de string menuOptions
            for (int i = 0; i < menuOptions.Length; i++)
            {
                //si i = menuSelect, ajoute "> " devant l'index de menuOptions, sinon n'ajoute rien
                Console.WriteLine((i == menuSelect ? "> " : "") + menuOptions[i]);
            }
            var keyPressed = Console.ReadKey();
            //Si flèche du bas pressée, et menuSelect < (taille de l'array de string - 1)
            if(keyPressed.Key == ConsoleKey.DownArrow && menuSelect < menuOptions.Length - 1)
            {
                //ajoute 1 à menuSelect
                menuSelect++;
            }
            //Si flèche du haut pressée, et menuSelect >= 1
            else if(keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                //enlève 1 à menuSelect
                menuSelect--;
            }
            //Si touche d'entrée pressée
            else if(keyPressed.Key == ConsoleKey.Enter)
            {
                //execute des actions en fonction de la valeur du menuSelect
                switch (menuSelect)
                {
                    case 0:
                        //ChoixEleve();
                        MenuEleves();
                        break;
                    case 1:
                        //ChoixCours();
                        MenuCours();
                        break;
                }
            }
        }        
    }
    public static void MenuEleves()
    {
        string[] menuOptions = new string[] { "Lister les élèves\t", "Ajouter un élève\t", "Consulter un élève\t", "Ajouter une note et une appréciation pour un cours sur un élève existant\t", "Menu Principal\t" };
        int menuSelect = 0;
        Eleve e = new Eleve();

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine((i == menuSelect ? "> " : "") + menuOptions[i]);
            }
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect < menuOptions.Length - 1)
            {
                menuSelect++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelect)
                {
                    case 0:
                        Console.Clear();
                        Eleve.listeEleves();
                        //e.readJson();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Nom: ");
                        string nom = Console.ReadLine();
                        Console.WriteLine("Prenom: ");
                        string prenom = Console.ReadLine();
                        Console.WriteLine("Date: ");
                        string date = Console.ReadLine();
                        Eleve.ajoutEleve(nom, prenom, date);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Id de l'élève à consulter: ");
                        string id = Console.ReadLine();
                        Eleve.ConsultEleve(Convert.ToInt32(id));
                        ChoixCours();
                        //Console.WriteLine("A faire... Consulter un élève");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Id de l'élève: ");
                        string eID = Console.ReadLine();
                        Eleve eleve = Eleve.eleves.Find(e => e.id == int.Parse(eID));
                        if(eleve != null)
                        {
                            eleve.ajoutNotes();
                        }
                        else
                        {
                            Console.WriteLine("Il n'existe pas d'élève avec cet identifiant");
                        }
                        //Console.WriteLine("A faire... Ajouter une note et une appréciation");
                        Console.ReadLine();
                        break;
                    case 4:
                        MenuPrincipal();
                        break;
                }
            }
        }
    }
    public static void MenuCours()
    {
        string[] menuOptions = new string[] { "Lister les cours\t", "Ajouter un nouveau cours\t", "Supprimer un cours\t", "Menu Principal\t" };
        int menuSelect = 0;

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine((i == menuSelect ? "> " : "") + menuOptions[i]);
            }
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect < menuOptions.Length - 1)
            {
                menuSelect++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelect)
                {
                    case 0:
                        Console.Clear();
                        Cours.listeCours();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Nom: ");
                        string nom = Console.ReadLine();
                        Cours.ajoutCours(nom);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("A faire... Supprimer le cours");
                        Console.ReadLine();
                        break;
                    case 3:
                        MenuPrincipal();
                        break;
                }
            }
        }
    }
    public static void ChoixEleve()
    {
        Console.Clear();
        Console.WriteLine("Liste des élèves");
        /*var consoleK = Console.ReadKey();
        if(consoleK.Key == ConsoleKey.Escape) { }*/
        Console.ReadLine();
    }
    public static void ChoixCours()
    {
        Console.Clear();
        Console.WriteLine("Liste des cours");
        Console.ReadLine();
        int menuSelect = 0;

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            for (int i = 0; i < Cours.cours.Count; i++)
            {
                Console.WriteLine((i == menuSelect ? "> " : "") + Cours.cours[i]);
            }
            Console.ReadLine();
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.DownArrow && menuSelect < Cours.cours.Count - 1)
            {
                menuSelect++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelect >= 1)
            {
                menuSelect--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)
            {
                switch (menuSelect)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("First choice");
                        Console.ReadLine();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Second choice");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Third choice");
                        Console.ReadLine();
                        break;
                    case 3:
                        MenuPrincipal();
                        Console.ReadLine();
                        break;
                }
            }
        }
    }

    public static void Main(string[] args) {
        MenuPrincipal();
        //MenuEleves();
        Console.WriteLine("Hello World");
        Eleve e = new Eleve();
        /*Eleve.ajoutEleve("Sumo", "Stephane", DateTime.Now);
        Eleve.ajoutEleve("Zeff", "Sophie", DateTime.Now);
        Eleve.ajoutEleve("Drake", "Stephane", DateTime.Now);
        Eleve.ajoutEleve("Meister", "Sophie", DateTime.Now);*/
        Eleve.listeEleves();

        Cours c = new Cours();
        Cours.ajoutCours("CSharp");
        Cours.listeCours();
    }
}