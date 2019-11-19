using System;
using System.Collections.Generic;
using System.Text;

namespace CodingGame.ShadowsOfTheKnightEp2
{
    internal struct Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int Distance(Position position)
        {
            return (int)Math.Sqrt(Math.Pow(this.X - position.X, 2) + Math.Pow(this.Y - position.Y, 2));
        }

        public override string ToString()
        {
            return $"{this.X} {this.Y}";
        }
    }
}
