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

        /*public Cours() 
        {
            id = ++incrementC;
        }*/
        public static void listLessons()
        {
            Console.Clear();
            foreach (Lesson c in lesson)
            {
                Console.WriteLine(c.name);
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
                lesson.Remove(les);
                Console.WriteLine($"Lesson with id {lessonID} successfully deleted");
            }
            else
            {
                Console.WriteLine("No lesson found with given Id");
            }
        }
    }
}
