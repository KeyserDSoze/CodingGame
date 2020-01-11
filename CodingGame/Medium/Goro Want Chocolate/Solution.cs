using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Goro_Want_Chocolate
{
    internal class Solution : ICodinGame
    {
        static int h = 150;
        static int w = 149;
        public void Run()
        {
            int[,] map = h > w ? new int[h + 1, h + 1] : new int[w + 1, w + 1];
            Console.WriteLine(GetNumberOfSquares(w, h, map));
        }
        private static int GetNumberOfSquares(int height, int width, int[,] map)
        {
            if (height == width)
                return 1;
            if (map[height, width] > 0)
                return map[height, width];

            int minHeight = int.MaxValue;
            for (int i = 1; i <= height / 2; i++)
                minHeight = Math.Min(GetNumberOfSquares(i, width, map) + GetNumberOfSquares(height - i, width, map), minHeight);

            int minWidth = int.MaxValue;
            for (int i = 1; i <= width / 2; i++)
                minWidth = Math.Min(GetNumberOfSquares(height, i, map) + GetNumberOfSquares(height, width - i, map), minWidth);

            return map[height, width] = Math.Min(minWidth, minHeight);
        }
    }
}
