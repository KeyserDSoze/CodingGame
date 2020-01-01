using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Dead_mens_shot
{
    class Solution : ICodinGame
    {
        //Triangle
        //static int N = 3;
        //static int[,] Points = new int[3, 2] { { 0, 0 }, { 400, 0 }, { 200, 200 } };
        //static int M = 5;
        //static int[,] Shots = new int[5, 2] { { 200, 100 }, { -34, 23 }, { 75, 5 }, { 175, 174 }, { 175, 176 } };

        //Square
        static int N = 4;
        static int[,] Points = new int[4, 2] { { -100, -100 }, { 100, -100 }, { 100, 100 }, { -100, 100 } };
        static int M = 5;
        static int[,] Shots = new int[5, 2] { { 0, 0 }, { 99, 99 }, { 101, 101 }, { 80, -101 }, { 0, -100 } };
        public void Run()
        {
            //http://www.dcs.gla.ac.uk/~pat/52233/slides/Geometry1x1.pdf
            //https://www.geeksforgeeks.org/how-to-check-if-a-given-point-lies-inside-a-polygon/
            //int distanceA = new Point(200, 66).DistanceFrom(new Point(175, 174));
            //int distanceB = new Point(200, 66).DistanceFrom(new Point(175, 176));
            //int distanceC = new Point(200, 66).DistanceFrom(new Point(0, 0));
            //int distanceD = new Point(200, 66).DistanceFrom(new Point(400, 0));
            //int distanceE = new Point(200, 66).DistanceFrom(new Point(200, 200));
            Figure figure = new Figure();
            for (int i = 0; i < N; i++)
            {
                int x = Points[i, 0];
                int y = Points[i, 1];
                figure.AddPoint(new Point(x, y));
                Console.WriteLine(new Point(x, y).AngularCoefficient(figure.Points.First()));
            }
            figure.CalculatDirection();
            for (int i = 0; i < M; i++)
            {
                int x = Shots[i, 0];
                int y = Shots[i, 1];
                Console.WriteLine(figure.IsHit(new Point(x, y)) ? "hit" : "miss");
            }
        }
    }
}
