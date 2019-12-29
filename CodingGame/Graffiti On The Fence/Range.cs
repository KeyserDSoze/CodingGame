using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Graffiti_On_The_Fence
{
    internal class Range
    {
        public int Start { get; private set; }
        public int End { get; private set; }
        public Range(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
        public void AmplifyRange(int start, int end)
        {
            if (start < this.Start)
                this.Start = start;
            if (end > this.End)
                this.End = end;
        }
    }
}
