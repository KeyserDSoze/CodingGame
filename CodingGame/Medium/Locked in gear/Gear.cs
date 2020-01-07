using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Locked_in_gear
{
    internal class Gear
    {
        public int X { get; }
        public int Y { get; }
        public int Radius { get; }
        public bool? IsClockwise { get; set; } = null;
        public int Position { get; set; } = int.MinValue;
        public List<Gear> Toucheds { get; set; } = new List<Gear>();
        public Gear(int x, int y, int radius)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }
        public bool Touching(Gear b)
            => this.Distance(b) <= this.Radius + b.Radius;
        public double Distance(Gear b)
            => Math.Sqrt(Math.Pow(b.X - this.X, 2) + Math.Pow(b.Y - this.Y, 2));
        public bool SetClockWise(Gear previous)
        {
            if (previous == null)
            {
                this.IsClockwise = true;
                this.Position = 0;
            }
            if (this.Position == 5)
            {
                string a = "";
            }
            bool check = true;
            foreach (Gear touched in this.Toucheds.Where(x => x != previous))
            {
                if (!touched.IsClockwise.HasValue)
                {
                    touched.IsClockwise = !this.IsClockwise.Value;
                    touched.Position = this.Position + 1;
                }
                else if (touched.IsClockwise.Value != !this.IsClockwise)
                    return false;
                check &= touched.SetClockWise(this);
            }
            return check;
        }
        public override string ToString()
            => $"{this.X} {this.Y} {this.Radius} => {this.Position} {(this.IsClockwise.HasValue ? this.IsClockwise.Value.ToString() : string.Empty)}";
    }
}
