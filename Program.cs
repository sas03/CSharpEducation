﻿using SystemEducatif.Classes;

namespace SystemEducatif;

class Program
{
    public static Logger log = new Logger("log.txt");
    public static void MainMenu()
    {
        string[] menuOptions = new string[] { "Students\t", "Lessons\t" };
        int menuSelect = 0;

        //loop infinie du code à l'intérieur jusqu'au "break/return" pour terminer le programme
        while (true)
        {
            Console.Clear();
            //Enlève la visibilité du curseur en console
            Console.CursorVisible = false;
            Console.WriteLine("\t-----------------\nWelcome to the best Educational System in the World !!!\nYou can select between 2 options: Students or Lessons\n\t-----------------\n");
            Console.WriteLine("Pick your choice by pressing the Enter button while navigating with the up or down arrow: \n\nMain Menu\n---------\n");
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
                        StudentMenu();
                        break;
                    case 1:
                        LessonMenu();
                        break;
                }
            }
        }        
    }
    public static void StudentMenu()
    {
        string[] menuOptions = new string[] { "List Students\t", "Add a Student\t", "Check details on a Student\t", "Add a rating and appreciation for a lesson on an existing Student\t", "Main Menu\t" };
        int menuSelect = 0;
        Student e = new Student();
        log.Log("Student Menu Selected");

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("\n\nStudent Menu\n---------\n");
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
                        log.Log("Student List Selected");
                        Student.listStudents();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Add a new Student\n--------------\n");
                        Console.WriteLine("Enter the name: ");
                        string nom = Console.ReadLine();
                        log.Log($"Name {nom} given");

                        Console.WriteLine("Enter the firstname: ");
                        string prenom = Console.ReadLine();
                        log.Log($"Firstname {prenom} given");
                        
                        Console.WriteLine("Enter the Day of Birth in this format (dd-MM-yyyy HH:mm:ss): ");
                        string date = Console.ReadLine();
                        log.Log($"Day of Birth {date} given");
                        
                        Student.addStudent(nom, prenom, date);
                        log.Log("Student Added");
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Student's Id to checkout: ");
                        string id = Console.ReadLine();
                        log.Log($"Student {id} given");

                        Student.CheckStudent(Convert.ToInt32(id));
                        log.Log($"Details of student with id {id} given");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        Student.addNotes();
                        //Student.readJson();
                        Console.ReadLine();
                        break;
                    case 4:
                        log.Log("Back to Main Menu");
                        MainMenu();
                        break;
                }
            }
        }
    }
    public static void LessonMenu()
    {
        string[] menuOptions = new string[] { "List lessons\t", "Add a new lesson\t", "Delete a lesson\t", "Main Menu\t" };
        int menuSelect = 0;
        log.Log("Menu Cours Selected");

        while (true)
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("\n\nLesson Menu\n---------\n");
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
                        log.Log("List Lessons");
                        Lesson.listLessons();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Add a new Lesson\n--------------\n");
                        Console.WriteLine("Enter the lesson name: ");
                        string nom = Console.ReadLine();
                        log.Log($"Lesson {nom} given");
                        
                        Lesson.addLesson(nom);
                        log.Log($"Lesson {nom} added");
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter Id of the lesson to delete: ");
                        string id = Console.ReadLine();
                        Lesson.deleteLesson(Int32.Parse(id));
                        log.Log($"Lesson with id {id} successfully deleted");
                        Console.ReadLine();
                        break;
                    case 3:
                        log.Log("Back to Main Menu");
                        MainMenu();
                        break;
                }
            }
        }
    }

    public static void Main(string[] args) {
        MainMenu();
    }
}