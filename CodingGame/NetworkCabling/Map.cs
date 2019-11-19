using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingGame.NetworkCabling
{
    internal class Map
    {
        private IEnumerable<Point> Points = new List<Point>();
        private int N;
        private long SumOfX = 0;
        private long SumOfY = 0;
        private long MinX = long.MaxValue;
        private long MinY = long.MaxValue;
        private long MaxX = long.MinValue;
        private long MaxY = long.MinValue;
        private Point Average;
        private long AverageDistance;
        private bool OnXAxys;

        private void CalculateAverage()
        {
            this.Average = new Point(this.SumOfX / this.N, this.SumOfY / this.N);
            this.Average = this.Points.OrderBy(x => x.TaxicabDistance(this.Average)).FirstOrDefault();
            Solution.Log($"Avg: {this.Average}");
            this.OnXAxys = this.MaxX - this.MinX < this.MaxY - this.MinY;
            if (this.OnXAxys)
            {
                this.AverageDistance = Math.Abs(this.MaxY - this.MinY);
                this.Points = this.Points.OrderBy(ƒ => ƒ.Y).ThenBy(ƒ => ƒ.X);
            }
            else
            {
                this.AverageDistance = Math.Abs(this.MaxX - this.MinX);
                this.Points = this.Points.OrderBy(ƒ => ƒ.X).ThenBy(ƒ => ƒ.Y);
            }
            Solution.Log($"Avg distance: {this.AverageDistance}");
        }

        private long DistanceFromAverageLine(Point p)
        {
            if (this.OnXAxys)
                return Math.Abs(p.X - this.Average.X);
            else
                return Math.Abs(p.Y - this.Average.Y);
        }

        private long DistanceFromTwoPoints(Point p1, Point p2)
        {
            if (this.OnXAxys)
                return Math.Abs(p2.Y - p1.Y);
            else
                return Math.Abs(p2.X - p1.X);
        }

        public Map(int n)
        {
            this.N = n;
        }

        public void SetPoint(Point value)
        {
            (this.Points as List<Point>).Add(value);
            this.SumOfX += value.X;
            this.SumOfY += value.Y;
            if (value.X < this.MinX)
                this.MinX = value.X;
            if (value.X > this.MaxX)
                this.MaxX = value.X;
            if (value.Y < this.MinY)
                this.MinY = value.Y;
            if (value.Y > this.MaxY)
                this.MaxY = value.Y;
        }

        public void CalculateDistancesWithMedia()
        {
            this.CalculateAverage();
            long sum = this.AverageDistance;
            foreach (Point p in this.Points)
                sum += this.DistanceFromAverageLine(p);
            Solution.Log(sum);
        }

        public void CalculateDistancesWithMedia2()
        {

            this.CalculateAverage();
            long sum = 0;
            Point previous = null;
            foreach (Point p in this.Points)
            {
                if (previous != null)
                {
                    long distanceFromPrevious = p.TaxicabDistance(previous);
                    long distanceFromAverageLine = this.DistanceFromAverageLine(p) + this.DistanceFromTwoPoints(previous, p);
                    if (distanceFromPrevious < distanceFromAverageLine)
                        sum += distanceFromPrevious;
                    else
                        sum += distanceFromAverageLine;
                }
                else
                    sum += this.DistanceFromAverageLine(p);
                previous = p;
            }
            Solution.Log(sum);
        }
    }
}
