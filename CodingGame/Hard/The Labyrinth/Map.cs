using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Hard.The_Labyrinth
{
    class Position
    {
        public int X { get; }
        public int Y { get; }
        public PosiotionType Type { get; set; }
        public bool Visited { get; set; }
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    enum PosiotionType
    {
        Unknown,
        Start,
        End,
        Way,
        Wall,
    }
    class Map
    {
        public List<Position> Cells { get; } = new List<Position>();
        public Position this[int x, int y]
            => this.Cells.FirstOrDefault(ƒ => ƒ.X == x && ƒ.Y == y);
        public bool HasCell(int x, int y)
            => this.Cells.Any(ƒ => ƒ.X == x && ƒ.Y == y);
        public void SetRow(int row, string value)
        {
            int y = 0;
            foreach (char c in value)
            {
                if (!HasCell(row, y))
                    this.Cells.Add(new Position(row, y));
                switch (c)
                {
                    case '?':
                        this[row, y].Type = PosiotionType.Unknown;
                        break;
                    case '#':
                        this[row, y].Type = PosiotionType.Wall;
                        break;
                    case '.':
                        this[row, y].Type = PosiotionType.Way;
                        break;
                    case 'T':
                        this[row, y].Type = PosiotionType.Start;
                        break;
                    case 'C':
                        this[row, y].Type = PosiotionType.End;
                        break;
                }
                
                y++;
            }
        }
    }
}
