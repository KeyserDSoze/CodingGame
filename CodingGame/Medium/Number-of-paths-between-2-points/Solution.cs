using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CodinGame.Medium.Number_of_paths_between_2_points
{
    class Solution : ICodinGame
    {
        readonly List<string> Rows = new List<string> { "00", "00" };
        int M => Rows.Count;
        int N => Rows.First().Length;
        readonly Dictionary<string, char> Maps = new Dictionary<string, char>();
        int Paths;
        public void Run()
        {
            for (int i = 0; i < M; i++)
            {
                string ROW = Rows[i];
                for (int j = 0; j < N; j++)
                {
                    Maps.Add($"{i}-{j}", ROW[j]);
                }
            }
            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            Check(0, 0);
            Console.WriteLine(Paths);
        }
        bool IsVisitable(int x, int y)
        {
            return Maps.ContainsKey($"{x}-{y}") && Maps[$"{x}-{y}"] == '0';
        }
        void Check(int x, int y)
        {
            if (x == M - 1 && y == N - 1)
                Paths += 1;
            //down
            if (IsVisitable(x + 1, y))
            {
                Check(x + 1, y);
            }
            //right
            if (IsVisitable(x, y + 1))
            {
                Check(x, y + 1);
            }
        }
    }
}
