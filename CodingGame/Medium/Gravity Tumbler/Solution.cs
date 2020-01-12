using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Gravity_Tumbler
{
    internal class Solution : ICodinGame
    {

        static List<string> Inputs = new List<string>()
        {
            ".................",
            ".................",
            "...##...###..#...",
            ".####..#####.###.",
            "#################"
        };
        static int count = 3;
        public void Run()
        {
            int width = Inputs.First().Length;
            int height = Inputs.Count;
            char[,] lines = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                string line = Inputs[i];
                for (int j = 0; j < width; j++)
                    lines[i, j] = line[j];
            }
            for (int i = 0; i < count; i++)
                lines = Entails(lines);
            Draw(lines);
        }
        private static void Draw(char[,] lines)
        {
            int x = lines.GetLength(0);
            int y = lines.GetLength(1);
            for (int i = 0; i < x; i++)
            {
                string value = "";
                for (int j = 0; j < y; j++)
                    value += lines[i, j];
                Console.WriteLine(value);
            }
        }
        private static char[,] Entails(char[,] lines)
        {
            int x = lines.GetLength(1);
            int y = lines.GetLength(0);
            char[,] newLines = new char[x, y];
            for (int i = 0; i < y; i++)
                for (int j = 0; j < x; j++)
                    newLines[j, i] = lines[i, j];
            lines = newLines;
            for (int j = 0; j < x; j++)
            {
                for (int i = x - 1; i > 0; i--)
                {
                    for (int k = 0; k < y; k++)
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
            return lines;
        }
    }
}
