using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Dead_mens_shot
{
    internal class Figure
    {
        public List<Point> Points { get; } = new List<Point>();
        public Point Average { get; private set; }
        public void AddPoint(Point point)
        {
            this.Points.Add(point);
        }
        public void CalculateAveragePoint()
        {
            this.Average = new Point(this.Points.Select(x => x.X).Sum() / this.Points.Count,
                this.Points.Select(x => x.Y).Sum() / this.Points.Count);
        }
        private static double Median(Point a, Point b)
        {
            int up = a.Y - b.Y;
            int down = a.X - b.X;
            if (up == 0 || down == 0)
                return 0;
            return (double)up / (double)down;
        }
        public bool IsHit(Point p)
        {
            foreach (Point c in this.Points)
            {
                if (c.X >= this.Average.X && p.X >= this.Average.X && p.X <= c.X)
                {
                    if (c.Y >= this.Average.Y && p.Y >= this.Average.Y && p.Y <= c.Y)
                        return true;
                    else if (c.Y <= this.Average.Y && p.Y <= this.Average.Y && p.Y >= c.Y)
                        return true;
                }
                else if (c.X <= this.Average.X && p.X <= this.Average.X && p.X >= c.X)
                {
                    if (c.Y >= this.Average.Y && p.Y >= this.Average.Y && p.Y <= c.Y)
                        return true;
                    else if (c.Y <= this.Average.Y && p.Y <= this.Average.Y && p.Y >= c.Y)
                        return true;
                }
            }
            return false;
        }
    }
}
