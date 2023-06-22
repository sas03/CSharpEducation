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
                Console.WriteLine(e.name + " " + e.firstname + "'s rating is: " + sum / e.data.Count + " on average.");
            }
        }
        /*public Eleve()
        {
            id = incrementE++;
        }*/
        public static void listStudents()
        {
            Console.Clear();
            foreach (Student e in students)
            {
                Console.WriteLine(e.id + "- " + e.name + " " + e.firstname + " " + e.dateOfBirth.ToString("yyyy-MM-dd HH:mm:ss"));
                if(e.data.Count != 0)
                {
                    Console.WriteLine("Notes");
                    foreach(Notes n in e.data)
                    {
                        Console.WriteLine("Lesson: " + n.lesson_id.name + " Score: " + n.note + " Appreciation: " + n.appreciation);
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
                Student newE = new Student()
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
                Console.WriteLine("Wrong Date Format");
            }
            Console.ReadLine();
        }
        public void readJson()
        {
            string json = File.ReadAllText("education.json");
            List<Student> students = JsonSerializer.Deserialize<List<Student>>(json);
            foreach(Student e in students)
            {
                Console.WriteLine(e.name + e.firstname);
            }
            Console.ReadLine();
        }
        public static void CheckStudent(int id)
        {
            Console.Clear();
            Student eleveConsulte = students.FirstOrDefault(e => e.id == id);
            if (eleveConsulte != null)
            {
                Console.WriteLine(eleveConsulte.id + "- " + eleveConsulte.name + " " + eleveConsulte.firstname + " " + eleveConsulte.dateOfBirth.ToString("yyyy-MM-dd HH:mm:ss"));
                double sum = 0;
                foreach (Notes n in eleveConsulte.data)
                {
                    sum = sum + n.note;
                }
                Console.WriteLine(eleveConsulte.name + " " + eleveConsulte.firstname + "'s rating is: " + sum / eleveConsulte.data.Count + " / 20 on average" );
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Student with id " + id + " doesn't exist.");
                Console.ReadLine();
            }
        }
        public void addNotes()
        {
            Console.Clear();
            Console.WriteLine("Id du cours: ");
            int cID = Convert.ToInt32(Console.ReadLine());
            Lesson lesson = Lesson.lesson.Find(c => c.id == cID);
            if (lesson != null)
            {
                Console.WriteLine("Note: ");
                double n = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Do you want to add an appreciation ? (Yes/No)");
                string answer = Console.ReadLine();
                if (answer == "Yes")
                {
                    Console.WriteLine("Enter your appreciation: ");
                    string appreciate = Console.ReadLine();
                    data.Add(new Notes()
                    {
                        lesson_id = lesson,
                        note = n,
                        appreciation = appreciate

                    });
                }
                else if (answer == "No")
                {
                    data.Add(new Notes()
                    {
                        lesson_id = lesson,
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
                Console.WriteLine("Lesson with this id doesn't exist");
            }
        }
    }

    public class Notes
    {
        public int id { get; set; }
        public Lesson lesson_id { get; set; }
        //public Eleve eleve_id { get; set; }
        public double note { get; set; }
        public string appreciation { get; set; }
    }
}

