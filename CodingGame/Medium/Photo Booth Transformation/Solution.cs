using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Photo_Booth_Transformation
{
    internal class Solution : ICodinGame
    {
        List<(int, int)> Inputs = new List<(int, int)>()
        {
            (2, 4),
            (6, 10),
            (1716, 638)
        };
        public void Run()
        {
            int T = Inputs.Count;
            for (int i = 0; i < T; i++)
            {
                int W = Inputs[i].Item1;
                int H = Inputs[i].Item2;
                Console.WriteLine(Calculate(W, H));
            }
        }
        private static int Calculate(int w, int h)
        {
            int middleWidth = w / 2;
            int middleHeight = h / 2;
            int startX = 1;
            int startY = 1;
            int newX = 1;
            int newY = 1;
            int count = 0;
            do
            {
                newX = Calc(newX, middleHeight);
                newY = Calc(newY, middleWidth);
                count++;
            } while (!(startX == newX && startY == newY));
            return count;
        }
        private static int Calc(int value, int middle)
        {
            if (value % 2 == 0)
                return value / 2;
            else
                return value / 2 + middle;
        }
        private static void NotOptimizedSolution(int H, int W)
        {
            int[,] array = new int[H, W];
            int[,] transformed = new int[H, W];
            int index = 0;
            for (int j = 0; j < H; j++)
            {
                for (int k = 0; k < W; k++)
                {
                    array[j, k] = index;
                    transformed[j, k] = index;
                    index++;
                }
            }
            int count = 0;
            do
            {
                transformed = Transform(transformed, W, H);
                count++;
                if (transformed[1, 1] == 1717)
                {
                    string err = "*7";
                }
            } while (!Equals(array, transformed, W, H));
            Console.WriteLine(count);
        }
        private static bool Equals(int[,] a, int[,] b, int w, int h)
        {
            for (int j = 0; j < h; j++)
                for (int k = 0; k < w; k++)
                    if (a[j, k] != b[j, k])
                        return false;
            return true;
        }
        private static int[,] Transform(int[,] map, int w, int h)
        {
            int[,] array = new int[h, w];
            int x = 0;
            for (int a = 0; a < 2; a++)
            {
                for (int j = a; j < h; j += 2)
                {
                    int y = 0;
                    for (int b = 0; b < 2; b++)
                    {
                        for (int k = b; k < w; k += 2)
                        {
                            array[x, y] = map[j, k];
                            y++;
                        }
                    }
                    x++;
                }
            }
            return array;
        }
    }
}
