using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodinGame.Medium.Green_Valleys
{
    class Solution : ICodinGame
    {
        static int H = 100;
        static int N = 5;
        List<string> Inputs = new List<string>()
        {
            //"8 9 9 8 7",
            //"8 2 3 2 7",
            //"6 4 5 4 8",
            //"9 8 4 2 7",
            //"7 8 9 6 5",
            //"1230 1241 1223 1244",
            //"1002 1014 1223 1244",
            //"1230 1241 1072 1244",
            //"1230 1132 1118 1171",
            "120 134 172 141 154",
            "171 100 121 91 132",
            "165 51 120 179 141",
            "162 73 145 81 87",
            "120 134 172 79 154",
        };
        public void Run()
        {
            int[,] map = new int[N, N];
            int[,] passed = new int[N, N];
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Inputs[i].Split(' ');
                for (int j = 0; j < N; j++)
                {
                    int h = int.Parse(inputs[j]);
                    map[i, j] = h;
                }
            }
            int max = 0;
            int deepest = int.MaxValue;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    var result = Next(i, j, N, N, map, H, passed);
                    if (result.Count > 0 && result.Count >= max)
                    {
                        if (result.Count == max)
                            deepest = Math.Min(result.Deepest, deepest);
                        else
                            deepest = result.Deepest;
                        max = result.Count;
                    }
                }
            }
            if (deepest == int.MaxValue)
                deepest = 0;
            Console.WriteLine(deepest);
        }
        private static List<(int I, int J)> Attempts = new List<(int I, int J)>() { (0, -1), (0, 1), (-1, 0), (1, 0) };
        internal static (int Count, int Deepest) Next(int i, int j, int width, int height, int[,] map, int average, int[,] passed)
        {
            if (i >= 0 && i < height && j >= 0 && j < width && map[i, j] <= average)
            {
                if (passed[i, j] == 1)
                    return (0, int.MaxValue);
                passed[i, j] = 1;
                int count = 1;
                int deepest = map[i, j];
                foreach (var attempt in Attempts)
                {
                    int nextI = i + attempt.I;
                    int nextJ = j + attempt.J;
                    if (nextI >= 0 && nextI < height && nextJ >= 0 && nextJ < width && passed[nextI, nextJ] == 0)
                    {
                        var result = Next(nextI, nextJ, width, height, map, average, passed);
                        if (result.Count > 0)
                        {
                            deepest = Math.Min(deepest, result.Deepest);
                            count += result.Count;
                        }
                    }
                }
                return (count, deepest);
            }
            else
                return (0, int.MaxValue);
        }
    }
}
