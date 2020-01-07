using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Regular_polygons
{
    internal class Solution : ICodinGame
    {
        static int a = 3;
        static int b = 2147483647;
        public void Run()
        {
            List<int> fermats = new List<int>() { 3, 5, 15, 17, 51, 85, 255, 257, 771, 1285, 3855, 4369, 13107, 21845, 65535, 65537, 196611, 327685, 983055, 1114129, 3342387, 5570645, 16711935, 16843009, 50529027, 84215045, 252645135, 286331153, 858993459, 1431655765 };
            List<int> powersOfTwos = new List<int>() { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456, 536870912, 1073741824 };
            List<int> counts = new List<int>();
            foreach (int powerOfTwo in powersOfTwos)
            {
                if (powerOfTwo >= a && powerOfTwo <= b)
                    counts.Add(powerOfTwo);
                foreach (int fermat in fermats)
                {
                    int value = powerOfTwo * fermat;
                    if (value.IsOverflow(powerOfTwo, fermat) && value >= a && value <= b)
                        counts.Add(value);
                }
            }
            Console.WriteLine(counts.Distinct().Count());
        }
        private static void NotPerformantSolution()
        {
            int count = 0;
            List<uint> fermats = new List<uint>() { 3, 5, 15, 17, 51, 85, 255, 257, 771, 1285, 3855, 4369, 13107, 21845, 65535, 65537, 196611, 327685, 983055, 1114129, 3342387, 5570645, 16711935, 16843009, 50529027, 84215045, 252645135, 286331153, 858993459, 1431655765 };
            uint end = (uint)b;
            for (uint i = (uint)a; i <= end; i++)
            {
                if (i.IsPowerOfTwo())
                {
                    count++;
                }
                else
                {
                    foreach (uint fermat in fermats)
                    {
                        if (i >= fermat && i % fermat == 0)
                        {
                            uint result = i / fermat;
                            if (result.IsPowerOfTwo())
                            {
                                count++;
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
    internal static class IntExtensions
    {
        public static bool IsPowerOfTwo(this uint x) => (x & (x - 1)) == 0;
        public static bool IsOverflow(this int result, int a, int b)
            => a == result / b;
    }
}
