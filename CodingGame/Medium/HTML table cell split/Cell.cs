using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.HTML_table_cell_split
{
    internal class Cell
    {
        private static int AscendingId = 0;
        public int Id { get; }
        public int EndY { get; set; }
        public int EndX { get; set; }
        public int StartX { get; private set; }
        public int StartY { get; private set; }
        public int Width => this.EndY - this.StartY + 1;
        public int Height => this.EndX - this.StartX + 1;
        public Cell(int endY, int endX, int startX, int startY)
        {
            this.StartX = startX;
            this.StartY = startY;
            this.EndY = endY;
            this.EndX = endX;
            this.Id = AscendingId;
            AscendingId++;
        }
        public void MoveOnX(int x) => this.MoveOn(x, 0);
        public void MoveOnY(int y) => this.MoveOn(0, y);
        public void MoveOn(int x, int y)
        {
            this.StartX += x;
            this.EndX += x;
            this.StartY += y;
            this.EndY += y;
        }
        public override string ToString()
        {
            return $"{this.Width},{this.Height}";
        }
    }
}
