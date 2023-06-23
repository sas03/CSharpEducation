using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEducatif.Classes
{
    public class Lesson
    {
        public static int incrementC = 0;
        public int id { get; set; }
        public string name { get; set; }

        public static List<Lesson> lesson = new List<Lesson>();

        /*public Lesson() 
        {
            id = ++incrementC;
        }*/
        public static void listLessons()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------\n");
            Console.WriteLine("Lesson Informations: \n");
            foreach (Lesson c in lesson)
            {
                Console.WriteLine("Id: \t\t" + c.id + "\nLesson: \t" + c.name);
                Console.WriteLine("\n");
            }
            Console.ReadLine();
        }
        public static void addLesson(string nameC)
        {
            Console.Clear();
            lesson.Add(new Lesson()
            {
                id = ++incrementC,
                name = nameC
            });
        }

        public static void deleteLesson(int lessonID)
        {
            Lesson les = lesson.Find(c => c.id == lessonID);
            if(les != null)
            {
                // Retrieve list of students from the static List in Student class
                List<Student> students = Student.students;
                
                // Delete Student's associated notes
                foreach(Student student in students){
                    student.data.RemoveAll(n => n.lesson.id == lessonID);
                }
                lesson.Remove(les);
                Console.WriteLine($"Lesson {les.name} with id {lessonID} successfully deleted");
            }
            else
            {
                Console.WriteLine("No lesson found with given Id");
            }
        }
    }
}
