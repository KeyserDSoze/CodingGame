using System;
using System.Collections.Generic;
using System.Text;

namespace CodingGame.ShadowsOfTheKnightEp2
{
    class ShadowsMain
    {
        static int[] Entries = new int[5] { 8000, 8000, 31, 3200, 2100 };
        static Position Solution = new Position(0, 0);
        //static int[] Entries = new int[5] { 5, 16, 80, 1, 5 };
        //static Position Solution = new Position(4, 10);
        //static int[] Entries = new int[5] { 18, 32, 45, 17, 31 };
        //static Position Solution = new Position(2, 1);
        //static int[] Entries = new int[5] { 1, 100, 12, 0, 98 };
        //static Position Solution = new Position(0, 1);
        private const int MaxSteps = 12;
        internal static (bool, int) Start()
        {
            int W = Entries[0]; // width of the building.
            int H = Entries[1]; // height of the building.
            int N = Entries[2]; // maximum number of turns before game over.
            int X0 = Entries[3];
            int Y0 = Entries[4];
            int max = MaxSteps;
            Map map = new Map(W, H);
            Position previous = map.StartPoint(X0, Y0);
            Previous = previous;
            Position current = map.FirstJump();
            while (true && max > 0)
            {
                Position newPosition = map.Next(previous, current);
                if (newPosition.ToString() == Solution.ToString())
                    return (true, MaxSteps - max);
                previous = current;
                current = newPosition;
                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");
                max--;
            }
            return (false, MaxSteps - max);
        }
        private static Position Previous;
        internal static string IsNear(Position position)
        {
            int distance = position.Distance(Solution);
            int previousDistances = Previous.Distance(Solution);
            Previous = position;
            if (distance < previousDistances)
                return "WARMER";
            else if (distance > previousDistances)
                return "COLDER";
            else
                return "SAME";
        }
    }
}
