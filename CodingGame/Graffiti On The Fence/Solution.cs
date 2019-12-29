using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Graffiti_On_The_Fence
{
    internal class Solution : ICodinGame
    {
        static int L = 12;
        static List<string> Inputs = new List<string>()
        {
            "6 10",
            "0 4",
            "7 8",
            "3 7",
            "8 12"
        };
        static int N = Inputs.Count;

        public void Run()
        {
            List<Range> ranges = new List<Range>();
            for (int i = 0; i < N; i++)
            {
                string[] a = Inputs[i].Split(' ');
                int start = int.Parse(a[0]);
                int end = int.Parse(a[1]);
                Range existingRange = ranges.FirstOrDefault(x => (start >= x.Start && start < x.End) || (end <= x.End && end > x.Start));
                if (existingRange != null)
                    existingRange.AmplifyRange(start, end);
                else
                    ranges.Add(new Range(start, end));
            }
            int min = 0;
            bool never = true;
            foreach (Range r in ranges.OrderBy(x => x.Start))
            {
                if (r.Start > min)
                {
                    Console.WriteLine($"{min} {r.Start}");
                    min = r.End;
                    never = false;
                }
                else if (r.End > min)
                    min = r.End;
            }
            if (never)
                Console.WriteLine($"All painted");
            else if (min < L)
                Console.WriteLine($"{min} {L}");
        }
    }
}
