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
    public class Student
    {
        public static int incrementE = 0;
        public int id { get; set; }
        public string name { get; set; }
        public string firstname { get; set; }
        public DateTime dateOfBirth { get; set; }

        public List<Notes> data = new List<Notes>();
        
        public static List<Student> students = new List<Student>();

        /*public Student()
        {
            id = incrementE++;
        }*/
        public void Average(int id)
        {
            Console.Clear();
            double sum = 0;
            Student e = students.Find(e => e.id == id);
            if(e != null)
            {
                foreach(Notes n in e.data) {
                    sum = sum + n.note;
                }
                Console.WriteLine(e.name + " " + e.firstname + " scored: " + sum / e.data.Count + " on average.");
            }
        }
        public static void listStudents()
        {
            Console.Clear();
            foreach (Student e in students)
            {
                Console.WriteLine("----------------------------------------------------------------------\n");
                Console.WriteLine("Student Informations: \n");
                Console.WriteLine("Id: \t\t" + e.id + "\nName: \t\t" + e.name + "\nFirstname: \t" + e.firstname + "\nDay of Birth: \t" + e.dateOfBirth.ToString("yyyy-MM-dd HH:mm:ss") + "\n");
                if(e.data.Count != 0)
                {
                    Console.WriteLine("Results: ");
                    foreach(Notes n in e.data)
                    {
                        Console.WriteLine("Lesson: " + n.lesson.name + " Score: " + n.note + " Appreciation: " + n.appreciation);
                        Console.WriteLine("\n");
                    }
                }
            }
            Console.ReadLine();
        }
        public static void addStudent(string nomE, string prenomE, string dateN)
        {
            Console.Clear();
            if (DateTime.TryParse(dateN, out DateTime date))
            {
                Student newE = students.Find(s => s.name == nomE && s.firstname == prenomE);
                if (newE == null)
                {
                    newE = new Student()
                    {
                        id = ++incrementE,
                        name = nomE,
                        firstname = prenomE,
                        dateOfBirth = date
                    };
                    students.Add(newE);

                    //serialize l'objet en une chaine de charactères JSON(Json string)
                    string json = JsonSerializer.Serialize(students);

                    //écrire la chaine JSON string en un fichier
                    File.WriteAllText("education.json", json);

                    Console.WriteLine("Student successfully added");
                }
                else
                {
                    Console.WriteLine($"Student {nomE} {prenomE} already exists");
                }
            }
            else
            {
                Console.WriteLine("Wrong Date Format");
            }
            Console.ReadLine();
        }
        public static void readJson()
        {
            string json = File.ReadAllText("education.json");
            students = JsonSerializer.Deserialize<List<Student>>(json);
            foreach(Student e in students)
            {
                Console.WriteLine(e.name + e.firstname);
            }
            Console.ReadLine();
        }
        public static void CheckStudent(int id)
        {
            Console.Clear();
            Student eleveConsulte = students.Find(e => e.id == id);
            if (eleveConsulte != null)
            {
                Console.WriteLine(eleveConsulte.id + "- " + eleveConsulte.name + " " + eleveConsulte.firstname + " " + eleveConsulte.dateOfBirth.ToString("yyyy-MM-dd HH:mm:ss"));
                double sum = 0;
                foreach (Notes n in eleveConsulte.data)
                {
                    sum = sum + n.note;
                }
                Console.WriteLine(eleveConsulte.name + " " + eleveConsulte.firstname + " scored: " + sum / eleveConsulte.data.Count + " / 20 on average" );
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Student with id " + id + " doesn't exist.");
                Console.ReadLine();
            }
        }
        public static void addNotes()
        {
            Console.Clear();
            string jsonContent = File.ReadAllText("education.json");
            students = JsonSerializer.Deserialize<List<Student>>(jsonContent);
            Console.WriteLine("Student id: ");
            if(int.TryParse(Console.ReadLine(), out int sID)){
                Student std = students.Find(s => s.id == sID);
                if(std != null){
                    Console.WriteLine("Lesson Id: ");
                    if(int.TryParse(Console.ReadLine(), out int cID)){
                        Lesson less = Lesson.lesson.Find(c => c.id == cID);
                        if (less != null)
                        {
                            Console.WriteLine("Note: ");
                            if(double.TryParse(Console.ReadLine(), out double n)){
                                Console.WriteLine("Do you want to add an appreciation ? (Yes/No)");
                                string answer = Console.ReadLine();
                                if (answer == "Yes")
                                {
                                    Console.WriteLine("Enter your appreciation: ");
                                    string appreciate = Console.ReadLine();
                                    Notes not = new Notes()
                                    {
                                        lesson = less,
                                        note = n,
                                        appreciation = appreciate
                                    };
                                    std.data.Add(not);
                                    string json = JsonSerializer.Serialize(std.data);
                                    File.WriteAllText("notes.json", json);
                                    Console.WriteLine("Note successfully added");
                                }
                                else if (answer == "No")
                                {
                                    std.data.Add(new Notes()
                                    {
                                        lesson = less,
                                        note = n,
                                        appreciation = null
                                    });
                                    string json = JsonSerializer.Serialize(std.data);
                                    File.WriteAllText("notes.json", json);
                                    Console.WriteLine("Note successfully added");
                                }
                                else
                                {
                                    Console.WriteLine("Wrong choix");
                                }
                            } else{
                                Console.WriteLine("Input must be a number. Try again");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Lesson with this id doesn't exist");
                        }
                    } else{
                        Console.WriteLine("Input must be a number. Try again");
                    }
                    //string json = JsonSerializer.Serialize(students);
                    //écrire la chaine JSON string en un fichier
                    //File.WriteAllText("education.json", json);
                    //Console.WriteLine("Student successfully added");
                    Console.ReadLine();
                    Console.Clear();
                }
            } else{
                Console.WriteLine("Input must be a number. Try again");
            }
        }
    }

    public class Notes
    {
        public int id { get; set; }
        public Lesson lesson { get; set; }
        public double note { get; set; }
        public string appreciation { get; set; }

        //public static List<Notes> notes = new List<Notes>();//Hold a collection of notes
    }
}

