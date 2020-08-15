using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodinGame.Easy.The_lost_child.Episode_1
{
    enum CellType
    {
        Wall,
        Way,
        Mom,
        Son,
    }
    class Position
    {
        public int X { get; }
        public int Y { get; }
        public CellType Value { get; }
        public Position(int x, int y, CellType value)
        {
            this.X = x;
            this.Y = y;
            this.Value = value;
        }
        public override string ToString()
            => $"{X}-{Y}";
        public int TaxicabDistance(Position position)
            => Math.Abs(this.X - position.X) + Math.Abs(this.Y - position.Y);
        public static bool operator !=(Position position, Position position2)
            => !(position == position2);
        public static bool operator ==(Position position, Position position2)
        {
            if (object.ReferenceEquals(position, null) && object.ReferenceEquals(position2, null))
                return true;
            else if (object.ReferenceEquals(position, null))
                return false;
            else if (object.ReferenceEquals(position2, null))
                return false;
            return position2.X == position.X && position2.Y == position.Y;
        }
    }
    class Path
    {
        public int Min { get; set; } = Int16.MaxValue;
    }
    class Map
    {
        public List<Position> Positions = new List<Position>();
        public Position this[int x, int y]
            => this.Positions.FirstOrDefault(ƒ => ƒ.X == x && ƒ.Y == y);
        public void AddPosition(string input)
        {
            int count = 0;
            int row = Positions.Count / 10;
            foreach (var c in input)
            {
                Positions.Add(new Position(row, count, FromChar(c)));
                count++;
            }
        }
        private CellType FromChar(char c)
        {
            switch (c)
            {
                case 'C':
                    return CellType.Son;
                case 'M':
                    return CellType.Mom;
                case '.':
                    return CellType.Way;
                default:
                    return CellType.Wall;
            }
        }
        public int GetMinWay()
            => GetMinWay(0, Start, new List<Position>()) - 1;

        public Position Start => Positions.FirstOrDefault(x => x.Value == CellType.Son);
        public Position End => Positions.FirstOrDefault(x => x.Value == CellType.Mom);
        private int MinDistance = int.MaxValue;
        private int GetMinWay(int minValue, Position position, List<Position> previous)
        {
            if (minValue + 1 >= MinDistance)
                return int.MaxValue;
            previous.Add(position);
            if (position.Value == CellType.Mom)
                return MinDistance = minValue + 1;
            if (position.Value == CellType.Wall)
                return Int16.MaxValue;

            int min = Int16.MaxValue;
            for (int i = -1; i < 2; i++)
            {
                if (i == 0)
                    continue;

                CheckPoint(this[position.X + i, position.Y], minValue, previous, ref min);
                CheckPoint(this[position.X, position.Y + i], minValue, previous, ref min);
            }
            return min;
        }
        private void CheckPoint(Position a, int minValue, List<Position> previous, ref int min)
        {
            if (a != null && !previous.Any(x => x == a))
            {
                int minA = GetMinWay(minValue + 1, a, previous.Select(x => x).ToList());
                if (minA < min)
                    min = minA;
            }
        }
    }
}