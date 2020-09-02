using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Hard.Super_Computer
{
    class Day
    {
        public int From { get; }
        public int To { get; }
        public int Distance { get; }
        public Day(int from, int distance)
        {
            this.From = from;
            this.To = from + distance - 1;
            this.Distance = distance;
        }
      
        public override string ToString()
            => $"{this.From}-{this.To} ({this.Distance})";
    }
}