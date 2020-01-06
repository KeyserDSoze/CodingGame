using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Rooks_Movements
{
    internal class Rock
    {
        private string Start;
        public int X { get; private set; }
        public int Y { get; private set; }
        public int MinX { get; private set; } = 0;
        public int MinY { get; private set; } = 0;
        public int MaxX { get; private set; } = 9;
        public int MaxY { get; private set; } = 9;
        private Dictionary<string, bool> Enemies = new Dictionary<string, bool>();
        private List<string> EatingPositions = new List<string>();

        public Rock(string position)
        {
            this.Start = position;
            this.X = (int)position[0] - 96;
            this.Y = int.Parse(position[1].ToString());
            Console.Error.WriteLine($"{this.X} {this.Y}");
        }

        public void SetMaxAndMin(string position, bool isEnemy)
        {
            int x = (int)position[0] - 96;
            int y = int.Parse(position[1].ToString());
            if (x == this.X && y > this.MinY && y <= this.Y)
                this.MinY = y;
            if (x == this.X && y < this.MaxY && y >= this.Y)
                this.MaxY = y;
            if (y == this.Y && x > this.MinX && x <= this.X)
                this.MinX = x;
            if (y == this.Y && x < this.MaxX && x >= this.X)
                this.MaxX = x;
            if (isEnemy)
                this.Enemies.Add(position, true);
        }
        public void Print()
        {
            for (int i = this.MinX; i <= this.X; i++)
            {
                string position = $"{(char)(i + 96)}{this.Y}";
                Check(position, i, this.X, this.MinX);
            }
            for (int i = this.MinY; i <= this.Y; i++)
            {
                string position = $"{(char)(this.X + 96)}{i}";
                Check(position, i, this.Y, this.MinY);
            }
            for (int i = this.Y; i <= this.MaxY; i++)
            {
                string position = $"{(char)(this.X + 96)}{i}";
                Check(position, i, this.MaxY, this.Y);
            }
            for (int i = this.X; i <= this.MaxX; i++)
            {
                string position = $"{(char)(i + 96)}{this.Y}";
                Check(position, i, this.MaxX, this.X);
            }
            foreach (string eated in this.EatingPositions)
                Console.WriteLine(eated);
        }
        private void Check(string position, int i, int max, int start)
        {
            if (this.Enemies.ContainsKey(position))
                this.EatingPositions.Add($"R{this.Start}x{position}");
            else if (i < max && i > start)
                Console.WriteLine($"R{this.Start}-{position}");
        }
    }
}
