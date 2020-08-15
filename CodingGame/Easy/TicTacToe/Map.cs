using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace CodinGame.Easy.TicTacToe
{
    class Position
    {
        public int X { get; }
        public int Y { get; }
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    class Cell
    {
        public Position Position { get; }
        public char Value { get; set; }
        public Cell(int x, int y, char value)
        {
            this.Position = new Position(x, y);
            this.Value = value;
        }
    }
    class Map
    {
        private static readonly List<List<Position>> Possibilities = new List<List<Position>>()
        {
            new List<Position>
            {
                new Position(0,0),
                new Position(0,1),
                new Position(0,2),
            },
            new List<Position>
            {
                new Position(1,0),
                new Position(1,1),
                new Position(1,2),
            },
            new List<Position>
            {
                new Position(2,0),
                new Position(2,1),
                new Position(2,2),
            },
            new List<Position>
            {
                new Position(0,0),
                new Position(1,0),
                new Position(2,0),
            },
            new List<Position>
            {
                new Position(0,1),
                new Position(1,1),
                new Position(2,1),
            },
            new List<Position>
            {
                new Position(0,2),
                new Position(1,2),
                new Position(2,2),
            },
            new List<Position>
            {
                new Position(0,0),
                new Position(1,1),
                new Position(2,2),
            },
            new List<Position>
            {
                new Position(2,0),
                new Position(1,1),
                new Position(0,2),
            },
        };
        public List<Cell> Cells = new List<Cell>();
        public Map() { }
        public Cell this[int x, int y]
            => this.Cells.FirstOrDefault(ƒ => ƒ.Position.X == x && ƒ.Position.Y == y);
        public void AddRow(string input)
        {
            int counter = 0;
            foreach (var t in input)
            {
                Cells.Add(new Cell(Cells.Count / 3, counter, t));
                counter++;
            }
        }
        public bool IsMine(Position point)
            => this[point.X, point.Y].Value == 'O';
        private bool HasSolution;
        public void SetWinning()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (this[i, j].Value == '.')
                    {
                        this[i, j].Value = 'O';
                        if (CheckWinning())
                            goto end;
                        else
                            this[i, j].Value = '.';
                    }
                }
            end: return;
        }
        private bool CheckWinning()
        {
            foreach (var possibility in Possibilities)
            {
                this.HasSolution = true;
                foreach (var point in possibility)
                {
                    this.HasSolution &= this.IsMine(point);
                    if (!this.HasSolution)
                        break;
                }
                if (this.HasSolution)
                    return true;
            }
            return false;
        }
        public IEnumerable<string> GetSolution()
        {
            if (!HasSolution)
                yield return "false";
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int j = 0; j < 3; j++)
                        stringBuilder.Append(this[i, j].Value);
                    yield return stringBuilder.ToString();
                }
            }
        }
    }
}