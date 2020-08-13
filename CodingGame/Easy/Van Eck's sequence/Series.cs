using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Easy.Van_Eck_s_sequence
{
    internal class Series
    {
        private readonly List<int> Serie = new List<int>();
        private readonly Dictionary<int, int> ComparedNumbers = new Dictionary<int, int>();
        public Series(int start, int n)
        {
            this.Serie.Add(start);
            int count = 1;
            while (count != n)
            {
                int last = this.Serie.Last();
                if (ComparedNumbers.ContainsKey(last)) 
                {
                    Serie.Add(count - ComparedNumbers[last]);
                    ComparedNumbers[last] = count;
                }
                else
                {
                    Serie.Add(0);
                    ComparedNumbers.Add(last, count);
                }
                count++;
            }
        }

        public int Last()
            => this.Serie.Last();
    }
}
