using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Hard.Connect_four
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        public Value Value { get; private set; }
        public Map Map { get; }
        public Point(int x, int y, Value value, Map map)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
            this.Map = map;
        }
        public override string ToString()
            => $"{this.X} {this.Y} {this.Value}";
        public bool IsAPlayableZone()
        {
            if (this.X == 0)
                return true;
            else
                return this.Map[this.X - 1, this.Y].Value > Value.None;
        }
        public bool HasWon(Value value)
        {
            Value before = this.Value;
            this.Value = value;
            bool check = false;
            check |= Calculation(value, this.Map.Width, i => this.Map[this.X, i]);
            check |= Calculation(value, this.Map.Height, i => this.Map[i, this.Y]);
            int leftY = this.Y - this.X;
            check |= leftY >= 0 && Calculation(value, 4, x => this.Map[x, leftY + x]);
            int rightY = this.Y + this.X;
            check |= rightY < this.Map.Width && Calculation(value, 4, x => this.Map[x, rightY - x]);
            this.Value = before;
            return check;
        }
        private bool Calculation(Value value, int max, Func<int, Point> pointGetter)
        {
            int count = 0;
            for (int i = 0; i < max; i++)
            {
                Point point = pointGetter(i);
                if (point != null && point.Value == value)
                    count++;
                else
                    count = 0;
                if (count >= 4)
                    return true;
            }
            return count >= 4;
        }
    }
    public enum Value
    {
        None,
        FirstPlayer,
        SecondPlayer,
    }
    public class Map
    {
        public List<Point> Points { get; } = new List<Point>();
        public Point this[int x, int y] => this.Points.FirstOrDefault(ƒ => ƒ.X == x && ƒ.Y == y);
        public int Width => 7;
        public int Height => 6;
        public Map(List<string> inputs)
        {
            for (int i = 5; i >= 0; i--)
                for (int j = 0; j < inputs[i].Length; j++)
                    this.Points.Add(new Point(5 - i, j, inputs[i][j] == '.' ? Value.None : (Value)int.Parse(inputs[i][j].ToString()), this));
        }
    }
}