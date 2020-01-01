using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dead_mens_shot
{
    internal class Point
    {
        public int X { get; }
        public int Y { get; }
        public double AngularCoefficientOnStartPoint { get; private set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.AngularCoefficientOnStartPoint = 0;
        }
        public int DistanceFrom(Point p)
            => (int)Math.Sqrt(Math.Pow(p.X - this.X, 2) + Math.Pow(p.Y - this.Y, 2));
        public double AngularCoefficient(Point point)
        {
            int up = point.Y - this.Y;
            int down = point.X - this.X;
            if (up == 0 || down == 0)
                return 0;
            return this.AngularCoefficientOnStartPoint = (double)up / (double)down;
        }
    }
}
