using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dead_mens_shot
{
    internal class Equation
    {
        public float M { get; }
        public float C { get; }
        public Direction Direction { get; }

        public Equation(Point a, Point b, Point directionPoint)
        {
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
        public bool Inside(Point p)
        {
            float y = this.SolveWithX(p);
            if (this.Direction == Direction.Up && y > p.Y)
                return false;
            if (this.Direction == Direction.Down && y < p.Y)
                return false;
            float x = this.SolveWithX(p);
            if (this.Direction == Direction.Up && y > p.Y)
                return false;
            if (this.Direction == Direction.Down && y < p.Y)
                return false;
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
