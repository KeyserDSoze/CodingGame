using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Seam_Carving
{
    internal class Pixel
    {
        public int Value { get; }
        public int Energy { get; set; }
        public int X { get; }
        public int Y { get; }
        public Pixel(int value, int x, int y)
        {
            this.Value = value;
            this.X = x;
            this.Y = y;
        }
    }
}
