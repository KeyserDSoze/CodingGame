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
            (6, 10)
        };
        public void Run()
        {
            int T = Inputs.Count;
            for (int i = 0; i < T; i++)
            {
                int W = Inputs[i].Item1;
                int H = Inputs[i].Item2;
                int[,] array = new int[H, W];
                for (int j = 0; j < H; j++)
                {
                    for (int k = 0; k < W; k++)
                    {
                        array[j, k] = j * k;
                    }
                }
            }
        }
        private static int[,] Transform(int[,] map, int w, int h)
        {
            int[,] array = new int[h, w];
            for (int j = 0; j < h; j++)
            {
                if (j % 2 == 0) { }
                for (int k = 0; k < w; k++)
                {
                    if (k % 2 == 0) { }
                }
            }
            return array;
        }
    }
}
