using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace eleventh_homework
{
    class Program
    {
        public static void ReadFile(string path, List<Student> lists)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string[] list = new string[3];
                    Student person = new Student();
                    string text = reader.ReadLine();
                    list = text.Split(" ");
                    person.name = list[0];
                    person.group = int.Parse(list[1]);
                    person.count = int.Parse(list[2]);

                    lists.Add(person);
                }
            }
        }

        public static void AddTofile(string fileName, string text)
        {
            File.AppendAllText(fileName, text);
        }

        public static void DeleteFromFile(string s, string txt)
        {
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(txt).Where(l => l != s);
            File.WriteAllLines(tempFile, linesToKeep);
            File.Delete(txt);
            File.Move(tempFile, txt);
        }
        public static List<double> Probability(List<double> vers)
        {
            double sum = vers.Sum();
            vers[0] /= sum;
            for (int i = 1; i < vers.Count; i++)
            {
                vers[i] = vers[i] / sum + vers[i - 1];
            }
            return vers;
        }

        public static void GetRNDIndex(Random rnd, List<double> vers, int ab)
        {
            double rndval = rnd.NextDouble();
            for (int i = 0; i < vers.Count; i++)
            {
                if (vers[i] > rndval)
                {
                    ab = i;

                }
            }
        }


        static void Main(string[] args)
        {
            ex2();
        }

        static void ex1()
        {
            string path = @"students.txt";
            string path2 = @"events.txt";
            Random rnd = new Random();
            List<Student> students = new List<Student>();
            ReadFile(path, students);
            List<double> vers = new List<double>();
            foreach (Student a in students)
            {
                vers.Add(a.count);
            }
            Console.WriteLine("Enter name of the event");
            string name = Console.ReadLine();
            Console.WriteLine("Enter date of the event");
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Wrong enter. Please try again");
            }
            Console.WriteLine("Date: {0}" + "\nName: {1}", date, name);
            Console.WriteLine("Enter needed number of students");
            int num;
            while (!Int32.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Wrong enter. Please try again");
            }
            int ind = 0;
            Probability(vers);
            string txt = $"Name of event: {name} Date: {date} Students: ";
            for (int i = 0; i < num; i++)
            {
                Student stu = new Student();
                GetRNDIndex(rnd, vers, ind);
                stu = students[ind];
                Console.WriteLine("Student {0}: ", i + 1);
                Console.WriteLine($"Name: {stu.name}  \nNumber of group: {stu.group}");
                students.RemoveAt(ind);
                DeleteFromFile($"{stu.name} {stu.group} {stu.count} ", path);
                AddTofile(path, $"{stu.name} {stu.group} {stu.count += 1}");
                txt += $"{stu.name} {stu.group} ";
            }
            AddTofile(path2, txt);
        }

        static void ex2()
        {
            List<People> students = new List<People>();
            People Adel = new People();
            Adel.name = "Adel";
            Adel.hobby = "figure skating";
            students.Add(Adel);

            People Leon = new People();
            Leon.name = "Leon";
            Leon.hobby = "reading";
            students.Add(Leon);
            People Daniya = new People();
            Daniya.name = "Daniya";
            Daniya.hobby = "cinematography";
            students.Add(Daniya);
            Adel.reacted += People.DisplayMessage;
            Daniya.reacted += People.DisplayMessage;
            Leon.reacted += People.DisplayMessage;
            Console.WriteLine("Enter a hobby");
            string hobby = Console.ReadLine();
            People.React(students, hobby);


        }


    }
}
