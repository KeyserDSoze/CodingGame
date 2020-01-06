using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Pirates_treasure
{
    internal class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>()
        {
            "1 1 1 0",
            "1 0 1 0",
            "1 1 1 1",
            "0 0 1 1"
        };
        static int H = Inputs.Count;
        static int W = Inputs[0].Length / 2 + 1;
        public void Run()
        {
            Point[,] points = new Point[H, W];
            for (int i = 0; i < H; i++)
            {
                string[] inputs = Inputs[i].Split(' ');
                for (int j = 0; j < W; j++)
                {
                    int value = int.Parse(inputs[j]);
                    points[i, j] = new Point(i, j, value);
                }
            }
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (points[i, j].IsValid && points[i, j].Value == 0)
                    {
                        for (int x = i == 0 ? 0 : i - 1; x <= i + 1 && x < H; x++)
                        {
                            for (int y = j == 0 ? 0 : j - 1; y <= j + 1 && y < W; y++)
                            {
                                if (!(x == i && y == j))
                                {
                                    points[x, y].ChangeValidity();
                                    if (points[x, y].Value == 0)
                                        points[i, j].ChangeValidity();
                                }
                            }
                        }
                        if (points[i, j].IsValid)
                        {
                            Console.WriteLine($"{j} {i}");
                            goto End;
                        }
                    }
                }
            }
        End: Console.Error.WriteLine("End");
        }
    }
}
