using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Short_accounts_make_long_friends
{
    public class Solution : ICodinGame
    {
        int result = 862;
        int a = 3;
        int b = 5;
        int c = 6;
        int d = 2;
        int e = 1;
        int f = 7;
        public void Run()
        {
            List<int> possibilities = new List<int>() { a, b, c, d, e, f };
            int min = Execute(result, possibilities, 0);
            Console.WriteLine(min);
        }
        public int Execute(int tot, List<int> possibilities, int step)
        {
            int min = int.MaxValue;
            for (int i = 0; i < possibilities.Count; i++)
            {
                int r0 = int.MaxValue;
                if (tot < 0 && tot + possibilities[i] == 0)
                    r0 = Execute(tot + possibilities[i], possibilities, step + 1);
                int r1 = int.MaxValue;
                if (tot > 0 && tot - possibilities[i] > 0)
                    r1 = Execute(tot - possibilities[i], possibilities, step + 1);
                else if (tot - possibilities[i] == 0)
                    return step + 1;
                int r2 = int.MaxValue;
                if (tot % possibilities[i] == 0)
                    r2 = Execute(tot / possibilities[i], possibilities, step + 1);
                int r3 = int.MaxValue;
                if (possibilities.Contains(tot * possibilities[i]) && step <= 100)
                    r3 = Execute(tot * possibilities[i], possibilities, step + 1);
                int minV = new List<int>() { r0, r1, r2, r3 }.Min();
                if (minV < min)
                    min = minV;
            }
            return min;
        }
    }
}
