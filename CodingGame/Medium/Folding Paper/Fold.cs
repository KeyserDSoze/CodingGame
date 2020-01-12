using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Folding_Paper
{
    internal class Fold
    {
        public int Up { get; private set; } = 1;
        public int Down { get; private set; } = 1;
        public int Left { get; private set; } = 1;
        public int Right { get; private set; } = 1;
        public void UpBlending()
        {
            this.Down += this.Up;
            this.Left *= 2;
            this.Right *= 2;
            this.Up = 1;
        }
        public void DownBlending()
        {
            this.Up += this.Down;
            this.Left *= 2;
            this.Right *= 2;
            this.Down = 1;
        }
        public void LeftBlending()
        {
            this.Right += this.Left;
            this.Up *= 2;
            this.Down *= 2;
            this.Left = 1;
        }
        public void RightBlending()
        {
            this.Left += this.Right;
            this.Up *= 2;
            this.Down *= 2;
            this.Right = 1;
        }
        public int FromThisPointOfView(string side)
        {
            switch (side)
            {
                case "U":
                    return this.Up;
                case "D":
                    return this.Down;
                case "L":
                    return this.Left;
                case "R":
                    return this.Right;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
