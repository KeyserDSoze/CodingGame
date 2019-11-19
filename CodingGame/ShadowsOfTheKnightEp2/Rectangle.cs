using System;
using System.Collections.Generic;
using System.Text;

namespace CodingGame.ShadowsOfTheKnightEp2
{
    internal class Rectangle
    {
        public int MinX { get; set; }
        public int MinY { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public static int Width;
        public static int Height;

        public Rectangle()
        {
            this.MaxX = Width;
            this.MaxY = Height;
        }

        public Position GetMiddle()
        {
            return new Position(this.MinX + (this.MaxX - this.MinX) / 2, this.MinY + (this.MaxY - this.MinY) / 2);
        }

        public Position GetMax()
        {
            return new Position(this.MaxX, this.MaxY);
        }

        public override string ToString()
        {
            return $"X: {this.MinX}-{this.MaxX} -- Y: {this.MinY}-{this.MaxY}";
        }
    }
}
