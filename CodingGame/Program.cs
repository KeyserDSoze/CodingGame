using System;
using System.Collections.Generic;
using System.Text;

namespace CodingGame
{
    class Program
    {
        static List<string> lines = new List<string>()
        {
            ">000#",
            "#0#00",
            "00#0#"
        };
        static void Main(string[] args)
        {
            int width = 5;
            int height = 3;
            Map map = new Map(width, height);
            int i = 0;
            foreach (string line in lines)
            {
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '#')
                        map.Zero(j, i);
                    else if (line[j] != '0')
                        map.SetStartPoint(j, i, line[j]);
                }
                i++;
            }
            map.SetDirection("L");
            map.Play();
        }
    }

    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        internal int Count { get; set; }
        private char Face;
        private static Point[] Points = new Point[4]
        {
            new Point('>'),
            new Point('v'),
            new Point('<'),
            new Point('^'),
        };

        public Point(char face)
        {
            this.Face = face;
            switch (face)
            {
                default:
                case '>':
                    this.X = 1;
                    this.Y = 0;
                    this.Count = 0;
                    break;
                case 'v':
                    this.X = 0;
                    this.Y = 1;
                    this.Count = 1;
                    break;
                case '<':
                    this.X = -1;
                    this.Y = 0;
                    this.Count = 2;
                    break;
                case '^':
                    this.X = 0;
                    this.Y = -1;
                    this.Count = 3;
                    break;
            }
        }
        public (int X, int Y) Add(int x, int y)
            => (x + this.X, y + this.Y);
        public void Rotate(int direction)
        {
            this.Count += direction;
            if (this.Count < 0)
                this.Count = 3;
            if (this.Count > 3)
                this.Count = 0;
            Point choose = Points[this.Count];
            this.X = choose.X;
            this.Y = choose.Y;
        }
    }

    public class Map
    {
        private int[,] Cells;
        private int Width;
        private int Height;
        private int StartX;
        private int StartY;
        private int Direction;
        private Point Face;

        public Map(int width, int height)
        {
            this.Cells = new int[width, height];
            this.Width = width;
            this.Height = height;
        }

        public void SetStartPoint(int i, int j, char face)
        {
            this.StartY = j;
            this.StartX = i;
            this.Face = new Point(face);
        }

        public void SetDirection(string direction)
        {
            if (direction == "L")
                this.Direction = 1;
            else
                this.Direction = -1;
        }

        public void Zero(int i, int j)
            => this.Cells[i, j] = int.MinValue;

        public void Play()
        {
            this.Cells[this.StartX, this.StartY]++;
            this.Play(this.StartX, this.StartY);
        }

        private void Play(int x, int y)
        {
            int count = 0;
            int resultX = 0;
            int resultY = 0;
            do
            {
                if (count > 0)
                    this.Face.Rotate(this.Direction);
                (int X, int Y) result = this.Face.Add(x, y);
                resultX = result.X;
                resultY = result.Y;
                count++;
            } while (count < 4 && (resultX < 0 || resultY < 0 || resultX >= this.Width || resultY >= this.Height || this.Cells[resultX, resultY] < 0));
            this.Cells[resultX, resultY]++;
            if (resultX == this.StartX && resultY == this.StartY)
            {
                this.Show();
            }
            else
            {
                this.Play(resultX, resultY);
            }
        }

        public void Show()
        {
            for (int j = 0; j < this.Height; j++)
            {
                StringBuilder end = new StringBuilder();
                for (int i = 0; i < this.Width; i++)
                {
                    end.Append(this.Cells[i, j] < 0 ? "#" : this.Cells[i, j].ToString());
                }
                Console.WriteLine(end.ToString());
            }
        }
    }
}
