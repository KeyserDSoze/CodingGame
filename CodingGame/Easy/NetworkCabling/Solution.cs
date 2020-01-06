using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.NetworkCabling
{
    internal class Solution : ICodinGame
    {
        private int N = 4;
        //private List<Point> Points = new List<Point>()
        //{
        //    new Point(-5,-3),
        //    new Point(-9,2),
        //    new Point(3,-4),
        //};
        private List<Point> Points = new List<Point>()
        {
            new Point(1,2),
            new Point(0,0),
            new Point(2,2),
        };
        public void Run()
        {
            this.N = this.Points.Count;
            Map map = new Map(this.N);
            foreach (Point point in this.Points)
                map.SetPoint(new Point(point.X, point.Y));
            map.CalculateDistancesWithMedia();
        }
        internal static void Log(object o)
            => Console.WriteLine(o);
    }
}
