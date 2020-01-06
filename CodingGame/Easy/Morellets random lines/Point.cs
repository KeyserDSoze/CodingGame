using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Morellets_random_lines
{
    internal class Point
    {
        public float X { get; }
        public float Y { get; }
        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public int DistanceFrom(Point p)
            => (int)Math.Sqrt(Math.Pow(p.X - this.X, 2) + Math.Pow(p.Y - this.Y, 2));
      
        public override string ToString()
        {
            return $"{this.X} {this.Y}";
        }
    }
}
