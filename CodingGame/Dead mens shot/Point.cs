using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dead_mens_shot
{
    internal class Point
    {
        public float X { get; }
        public float Y { get; }
        public double AngularCoefficientOnStartPoint { get; private set; }
        public Point(float x, float y)
        {
            this.X = x;
            this.Y = y;
            this.AngularCoefficientOnStartPoint = 0;
        }
        public int DistanceFrom(Point p)
            => (int)Math.Sqrt(Math.Pow(p.X - this.X, 2) + Math.Pow(p.Y - this.Y, 2));
        public double AngularCoefficient(Point point)
        {
            float up = point.Y - this.Y;
            float down = point.X - this.X;
            if (up == 0)
                return this.AngularCoefficientOnStartPoint = 0;
            if (down == 0)
                return this.AngularCoefficientOnStartPoint = 90;
            return this.AngularCoefficientOnStartPoint = (double)up / (double)down;
        }
        public override string ToString()
        {
            return $"{this.X} {this.Y} {this.AngularCoefficientOnStartPoint}";
        }
    }
}
