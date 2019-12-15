using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dead_mens_shot
{
    internal struct Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int DistanceFrom(Point p) 
            => (int)Math.Sqrt(Math.Pow(p.X - this.X, 2) + Math.Pow(p.Y - this.Y, 2));
    }
}
