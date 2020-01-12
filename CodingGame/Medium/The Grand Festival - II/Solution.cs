using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.The_Grand_Festival___II
{
    internal class Solution : ICodinGame
    {
        static int R = 2;
        static List<int> Inputs = new List<int>() { 10, 12, 11, 9, 17, 8, 13 };
        public void Run()
        {
            int N = Inputs.Count;
            List<Day> values = new List<Day>();
            for (int i = 0; i < N; i++)
            {
                int PRIZE = Inputs[i];
                values.Add(new Day(i + 1, PRIZE));
            }
            Console.WriteLine(string.Join(">", GetSummedPrices(0, R, values, new List<Day>[N + 1]).Select(x => x.X)));
        }
        internal static List<Day> GetSummedPrices(int i, int window, List<Day> values, List<Day>[] map)
        {
            if (map[i] != null)
                return map[i];
            int max = 0;
            List<Day> newValues = values.Skip(i).ToList();
            if (newValues.Count <= window)
                return map[i] = newValues;
            List<Day> days = new List<Day>();
            for (int j = 0; j < window; j++)
            {
                List<Day> next = newValues.Take(window - j).ToList();
                next.AddRange(GetSummedPrices(i + window - j + 1, window, values, map));
                int value = next.Sum(x => x.Value);
                if (value > max)
                {
                    max = value;
                    days = next;
                }
            }
            return map[i] = days;
        }
    }
}
