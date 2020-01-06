using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Gravity
{
    internal class Solution : ICodinGame
    {
        static int width = 17;
        static int height = 5;
        static List<string> Inputs = new List<string>()
        {
            "...#...#.#.#...#.",
             ".#..#...#....#...",
            "..........#......",
            "..###...###..##..",
            "#################",
        };
        public void Run()
        {
            char[,] lines = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                string line = Inputs[i];
                for (int j = 0; j < width; j++)
                    lines[i, j] = line[j];
            }
            for (int j = 0; j < height; j++)
            {
                for (int i = height - 1; i > 0; i--)
                {
                    for (int k = 0; k < width; k++)
                    {
                        if (lines[i, k] == '.' && lines[i - 1, k] == '#')
                        {
                            char c = lines[i, k];
                            lines[i, k] = lines[i - 1, k];
                            lines[i - 1, k] = c;
                        }
                    }
                }
            }

            for (int i = 0; i < height; i++)
            {
                string value = "";
                for (int j = 0; j < width; j++)
                    value += lines[i, j];
                Console.WriteLine(value);
            }
        }
    }
}
