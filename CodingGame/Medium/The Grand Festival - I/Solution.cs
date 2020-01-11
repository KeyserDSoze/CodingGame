using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.The_Grand_Festival___I
{
    internal class Solution : ICodinGame
    {
        static int R = 3;
        static List<int> Inputs = new List<int>() { 13, 12, 11, 9, 16, 17, 100 };
        public void Run()
        {
            int N = Inputs.Count;
            List<int> values = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int PRIZE = Inputs[i];
                values.Add(PRIZE);
            }
            Console.WriteLine(GetSummedPrices(0, R, values, new int[N + 1]));
        }
        internal static int GetSummedPrices(int i, int window, List<int> values, int[] map)
        {
            if (map[i] > 0)
                return map[i];
            int max = 0;
            List<int> newValues = values.Skip(i).ToList();
            if (newValues.Count <= window)
                return map[i] = newValues.Sum();
            for (int j = 0; j < window; j++)
            {
                int value = newValues.Take(window - j).Sum() + GetSummedPrices(i + window - j + 1, window, values, map);
                if (value > max)
                    max = value;
            }
            return map[i] = max;
        }
    }
}
