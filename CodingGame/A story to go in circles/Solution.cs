using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.A_story_to_go_in_circles
{
    class Solution : ICodinGame
    {
        static long ii = 7;
        static long nb = 4;
        public void Run()
        {
            List<string> lines = new List<string>();
            for (int i = 0; i < nb; i++)
                lines.Add(Console.ReadLine());
        }
    }
}
