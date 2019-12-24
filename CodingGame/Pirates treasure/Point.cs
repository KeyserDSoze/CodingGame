using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Pirates_treasure
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        public int Value { get; }
        public bool IsValid { get; private set; }

        public Point(int x, int y, int value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.IsValid = value == 0;
        }

        public void ChangeValidity()
            => this.IsValid = false;

    }
}
