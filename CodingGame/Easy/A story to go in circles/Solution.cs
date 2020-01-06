using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.A_story_to_go_in_circles
{
    class Solution : ICodinGame
    {
        static long ii = 98765432123;
        static int nb = 9;
        static List<string> Lines = new List<string>()
        {
            "a@cdefghi",
            "klmn#pqrs",
            "uvwxyzab@",
            "efghijk#m",
            "@pqrstuvw",
            "yza#cdefg",
            "ijklmn@pq",
            "stuvwxyza",
            "cd@fghijk",
        };
        //static long ii = 7;
        //static int nb = 4;
        //static List<string> Lines = new List<string>()
        //{
        //    "abcd",
        //    "dcba",
        //    "ba#d",
        //    "dabc",
        //};

        public void Run()
        {
            MyMap myMap = new MyMap(Lines, nb, ii);
            MyIterator myIterator = myMap.GetIterator();
            long counter = ii - 1;
            while (counter > 0)
            {
                counter = myIterator.Next(counter);
                Console.Error.WriteLine(myIterator.Current);
            }
            Console.WriteLine(myIterator.Current);
        }
    }
}
