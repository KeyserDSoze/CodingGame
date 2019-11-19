using System;
using System.Collections.Generic;
using System.Text;

namespace CodingGame.ShadowsOfTheKnightEp2
{
    internal class Position
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
            return Math.Abs(this.X - position.X) + Math.Abs(this.Y - position.Y);
        }

        public override string ToString()
        {
            return $"{this.X} {this.Y}";
        }

        public Position Next(Rectangle rectangle, Position previous)
        {
            string status = ShadowsMain.IsNear(this);
            if (previous != null)
                Player.Log($"prev: {previous.X} {previous.Y}");
            Player.Log($"{status} {this.X} {this.Y}");
            Player.Log(rectangle);
            switch (status)
            {
                default:
                case "UNKNOWN":
                    return rectangle.GetMiddle();
                case "COLDER":
                    return this.ColderNext(rectangle, previous);
                case "WARMER":
                    return this.WarmerNext(rectangle, previous);
                case "SAME":
                    return this.SameNext(rectangle, previous);
            }
        }
        private Position ColderNext(Rectangle rectangle, Position previous)
        {
            if (this.X > previous.X)
                rectangle.MaxX = this.X;
            else
                rectangle.MinX = this.X;

            if (this.Y > previous.Y)
                rectangle.MaxY = this.Y;
            else
                rectangle.MinY = this.Y;
            return rectangle.GetMiddle();
        }

        private Position WarmerNext(Rectangle rectangle, Position previous)
        {
            if (this.X > previous.X)
                rectangle.MinX = previous.X;
            else
                rectangle.MaxX = previous.X;

            if (this.Y > previous.Y)
                rectangle.MinY = previous.Y;
            else
                rectangle.MaxY = previous.Y;
            return rectangle.GetMiddle();
        }

        private Position SameNext(Rectangle rectangle, Position previous)
        {
            List<Position> positions = new List<Position>();
            for (int i = rectangle.MinX; i <= rectangle.MaxX; i++)
            {
                for (int j = rectangle.MinY; j <= rectangle.MaxY; j++)
                {
                    Position position = new Position(i, j);
                    if (position.Distance(this) == position.Distance(previous))
                        positions.Add(position);
                }
            }
            return positions[positions.Count / 2];
        }
    }
}
