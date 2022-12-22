using System;
using System.Collections.Generic;
using System.Text;

namespace eleventh_homework
{
    class People
    {
        public string name;
        public string hobby;

        public delegate void Reaction(string ms);
        public event Reaction reacted;

        public static void DisplayMessage(string message) => Console.WriteLine(" is happy");
        public static void React(List<People> list, string str)
        {

            foreach (People a in list)
            {
                if (a.hobby.Equals(str.ToLower()))
                {
                    Console.Write(a.name);
                    DisplayMessage($"{a.name} is happy");
                }
            }
        }
    }


}
