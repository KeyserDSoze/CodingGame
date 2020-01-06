using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Graffiti_On_The_Fence
{
    internal class Solution : ICodinGame
    {
        static int L = 7;
        static List<string> Inputs = new List<string>()
        {
            "1 4",
            "3 6",
            "0 2",
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
            List<Range> deletedRanges = new List<Range>();
            foreach (Range range in ranges.OrderBy(x => x.Start))
            {
                if (!deletedRanges.Any(x => x == range))
                {
                    Range existingRange = ranges.FirstOrDefault(x => range != x && ((range.Start >= x.Start && range.Start < x.End) || (range.End <= x.End && range.End > x.Start)));
                    if (existingRange != null)
                    {
                        range.AmplifyRange(existingRange.Start, existingRange.End);
                        deletedRanges.Add(existingRange);
                    }
                }
            }
            foreach (Range deletedRange in deletedRanges)
                ranges.Remove(deletedRange);
            if (ranges.Sum(x => x.End - x.Start) == L)
            {
                Console.WriteLine($"All painted");
            }
            else
            {
                int min = 0;
                foreach (Range r in ranges.OrderBy(x => x.Start))
                {
                    if (r.Start > min)
                    {
                        Console.WriteLine($"{min} {r.Start}");
                        min = r.End;
                    }
                    else if (r.End > min)
                        min = r.End;
                }
                if (min != L)
                    Console.WriteLine($"{min} {L}");
            }
        }
    }
}
