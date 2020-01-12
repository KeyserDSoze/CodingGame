using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Magic_stones
{
    class Solution : ICodinGame
    {
        static List<int> Inputs = new List<int>() { 1, 1, 1, 2, 2, 3, 3, 4, 4, 9 };
        public void Run()
        {
            int N = Inputs.Count;
            List<int> stones = new List<int>();
            for (int i = 0; i < N; i++)
            {
                int level = Inputs[i];
                Console.Error.WriteLine(level);
                stones.Add(level);
            }
            while (stones.Distinct().Count() < stones.Count && stones.Count > 1)
            {
                int value = stones.GroupBy(x => x).Select(x => (Value: x, Count: x.Count())).Where(x => x.Count > 1).OrderBy(x => x.Value.Key).FirstOrDefault().Value.Key;
                stones.Add(value + 1);
                int count = 0;
                for (int i = 0; i < stones.Count; i++)
                {
                    if (stones[i] == value)
                    {
                        stones.RemoveAt(i);
                        i--;
                        count++;
                    }
                    if (count == 2)
                        break;
                }
            }
            Console.WriteLine(stones.Count);
        }
    }
}
