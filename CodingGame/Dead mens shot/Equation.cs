using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dead_mens_shot
{
    internal class Equation
    {
        public Point A { get; }
        public Point B { get; }
        public float M { get; }
        public float C { get; }
        public Direction Direction { get; }

        public Equation(Point a, Point b, Point directionPoint)
        {
            this.A = a;
            this.B = b;
            if (b.X - a.X != 0)
            {
                this.M = (b.Y - a.Y) / (b.X - a.X);
                this.C = (a.Y * b.X - a.X * b.Y) / (b.X - a.X);
                this.Direction = this.SolveWithX(directionPoint) >= directionPoint.Y ? Direction.Down : Direction.Up;
            }
            else
            {
                this.M = 0;
                this.C = (a.X * b.Y - a.Y * b.X) / (b.Y - a.Y);
                this.Direction = this.SolveWithY(directionPoint) >= directionPoint.X ? Direction.Left : Direction.Right;
            }
        }
        public bool IsInside(Point p)
        {
            if (this.Direction == Direction.Up || this.Direction == Direction.Down)
            {
                float y = this.SolveWithX(p);
                if (this.Direction == Direction.Up && y > p.Y)
                    return false;
                if (this.Direction == Direction.Down && y < p.Y)
                    return false;
            }
            else
            {
                float x = this.SolveWithY(p);
                if (this.Direction == Direction.Left && x < p.X)
                    return false;
                if (this.Direction == Direction.Right && x > p.X)
                    return false;
            }
            return true;
        }
        public float SolveWithX(Point point)
            => this.M * point.X + this.C;
        public float SolveWithY(Point point)
            => this.M * point.Y + this.C;
    }
    internal enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
