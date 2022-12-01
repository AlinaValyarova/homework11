using System;
using System.Collections.Generic;
using System.Text;

namespace eleventh_homework
{
    class Students2
    {
        public string name;
        public string hobby;

        public delegate void Reaction(string ms);
        static event Reaction reacted;


        public static void React(List<Students2> list, string str)
        {
            foreach (var a in list)
            {
                if (a.hobby.Equals(str.ToLower()))
                {
                    reacted?.Invoke($"{a.name} is happy");
                }
                else
                {
                    Console.WriteLine("No one is happy");
                }
            }
        }
    }


}
