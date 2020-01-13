using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Windmill_problem
{
    class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>()
        {
            "200 200",
            "400 300",
            "400 100",
            //"654 114",
            //"25 281",
            //"250 228",
            //"142 104",
            //"692 558",
            //"89 432",
            //"32 30",
            //"95 223",
            //"238 517",
            //"616 27",
        };
        static int N = 3;
        static int P = 1;
        //static int N = 30;
        //static int P = 5;
        public void Run()
        {
            int K = Inputs.Count;
            List<Point> points = new List<Point>();
            for (int i = 0; i < K; i++)
            {
                string[] inputs = Inputs[i].Split(' ');
                int x = int.Parse(inputs[0]);
                int y = int.Parse(inputs[1]);
                points.Add(new Point(x, y));
            }
            Dictionary<int, int> nextPivots = new Dictionary<int, int>();
            Point pivot = points[P];
            pivot.Count++;
            double angularCoefficient = int.MaxValue;
            int nextPivot = K;
            Point previousPivot = null;
            for (int i = 0; i < N; i++)
            {
                if (nextPivots.ContainsKey(nextPivot))
                {
                    nextPivot = nextPivots[nextPivot];
                    points[nextPivot].Count++;
                }
                else
                {
                    double min = int.MaxValue;
                    int count = 0;
                    int previuosPivotValue = nextPivot;
                    foreach (Point point in points.Where(x => x != pivot && x != previousPivot))
                    {
                        if (point != pivot && point != previousPivot)
                        {
                            double value = point.AngularCoefficient(pivot);
                            Console.Error.WriteLine(value);
                            double difference = Math.Abs(1 - Math.Abs(value - angularCoefficient));
                            if (difference < min)
                            {
                                min = difference;
                                nextPivot = count;
                            }
                        }
                        count++;
                    }
                    angularCoefficient = pivot.AngularCoefficient(points[nextPivot]);
                    previousPivot = pivot;
                    pivot = points[nextPivot];
                    nextPivots.Add(previuosPivotValue, nextPivot);
                    pivot.Count++;
                }
            }
            Console.WriteLine(nextPivot);
            foreach (Point point in points)
                Console.WriteLine(point.Count);
        }
    }
    internal class Point
    {
        public int X { get; }
        public int Y { get; }
        public int Count { get; set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public double AngularCoefficient(Point point)
        {
            if (point.X == this.X)
                return int.MaxValue;
            return ((double)point.Y - (double)this.Y) / ((double)point.X - (double)this.X);
        }
    }
}
