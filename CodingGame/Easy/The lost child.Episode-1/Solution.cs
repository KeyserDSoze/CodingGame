using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Easy.The_lost_child.Episode_1
{
    class Solution : ICodinGame
    {
        private readonly List<string> Inputs = new List<string>
        {
            "..........",
            "M#........",
            "#C##......",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
            "..........",
        };
        public void Run()
        {
            Map map = new Map();
            for (int i = 0; i < 10; i++)
            {
                string row = Inputs[i];
                map.AddPosition(row);
                Console.Error.WriteLine($"\"{row}\",");
            }

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine($"{map.GetMinWay() * 10}km");
        }
    }
}