using System;
using System.Collections.Generic;
using System.Text;

namespace CodingGame.NetworkCabling
{
    internal class Point
    {
        public long X { get; }
        public long Y { get; }
        public Point(long x, long y)
        {
            this.X = x;
            this.Y = y;
        }

        public long TaxicabDistance(Point point)
            => Math.Abs(this.X - point.X) + Math.Abs(this.Y - point.Y);
        public override string ToString()
            => $"{this.X};{this.Y}";
    }
}
