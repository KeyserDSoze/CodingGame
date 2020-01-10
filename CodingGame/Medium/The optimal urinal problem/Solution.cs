using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.The_optimal_urinal_problem
{
    internal class Solution : ICodinGame
    {
        private static int n = 7;
        public void Run()
        {
            int[] map = new int[n];
            for (int i = 0; i < n; i++)
                map[i] = -1;
            int step = n / 2;
            int count = 0;
            int index = 0;
            long maxStep = 0;
            if (n > 2)
            {
                while (count <= step)
                {
                    long total =
                        (map[count] > -1 ? map[count] : GetBestPosition(0, count, map)) +
                            (map[n - 1 - count] > -1 ? map[n - 1 - count] : GetBestPosition(count, n - 1, map)) +
                                (count > 1 ? 3 : 2);
                    if (maxStep < total)
                    {
                        maxStep = total;
                        index = count + 1;
                    }
                    count++;
                }
                Console.WriteLine($"{maxStep} {index}");
            }
            else
                Console.WriteLine($"1 1");
        }
        private static int GetBestPosition(int previous, int current, int[] map)
        {
            int distance = current - previous;
            if (distance <= 3)
                return 0;
            int middlePosition = (previous + current) / 2;
            map[distance] =
                map[distance] > -1 ?
                    map[distance] : GetBestPosition(previous, middlePosition, map) + GetBestPosition(middlePosition, current, map) + 1;
            return map[distance];
        }
    }
}
