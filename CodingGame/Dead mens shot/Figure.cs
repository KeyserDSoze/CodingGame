using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Dead_mens_shot
{
    internal class Figure
    {
        public List<Point> Points { get; } = new List<Point>();
        public List<Equation> Equations = new List<Equation>();
        public void AddPoint(Point point)
        {
            this.Points.Add(point);
        }
        public Point CalculateAveragePoint()
        {
            return new Point(this.Points.Select(x => x.X).Sum() / this.Points.Count,
                this.Points.Select(x => x.Y).Sum() / this.Points.Count);
        }
        public void CalculatDirection()
        {
            Point average = this.CalculateAveragePoint();
            List<Point> points = new List<Point>();
            foreach (Point p in this.Points)
                points.Add(p);
            Point first = points.OrderBy(x => x.Y + x.X).First();
            Point aPoint = first;
            points.Remove(first);
            while (this.Equations.Count < this.Points.Count - 1)
            {
                Point bPoint = points.OrderBy(x => x.DistanceFrom(aPoint)).First();
                this.Equations.Add(new Equation(aPoint, bPoint, average));
                aPoint = bPoint;
                points.Remove(bPoint);
            }
            this.Equations.Add(new Equation(aPoint, first, average));
        }
        public bool IsHit(Point p)
        {
            foreach(Equation equation in this.Equations)
            {
                float y = equation.SolveWithX(p);
                if (equation.Direction == Direction.Up && y > p.Y)
                    return false;
                if (equation.Direction == Direction.Down && y < p.Y)
                    return false;
            }
            return true;
        }
    }
}
