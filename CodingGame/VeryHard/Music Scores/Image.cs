using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.VeryHard.Music_Scores
{
    class Interval
    {
        public int Start { get; }
        public int End { get; }
        public Interval(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
        public override string ToString()
            => $"{Start}-{End}";
    }
    class Note
    {
        public string Value { get; }
        public string Type { get; }
        public Note(string value, string type)
        {
            this.Value = value;
            this.Type = type;
        }
    }
    class Position
    {
        public int X { get; }
        public int Y { get; }
        public bool Top { get; }
        public Position(int x, int y, bool top)
        {
            this.X = x;
            this.Y = y;
            this.Top = top;
        }
        public override string ToString()
          => $"{X}-{Y}";
    }
    class Image
    {
        public int Width { get; }
        public int Height { get; }
        public int Wide { get; private set; }
        public int[,] Map { get; }
        public List<Interval> Intervals { get; }
        public Image(int width, int height, string image)
        {
            this.Width = width;
            this.Height = height;
            Queue<int> baseMap = new Queue<int>();
            string[] app = image.Split(' ');
            for (int i = 0; i < app.Length; i += 2)
            {
                int value = app[i] == "W" ? 1 : 0;
                int times = int.Parse(app[i + 1]);
                for (int j = 0; j < times; j++)
                    baseMap.Enqueue(value);
            }
            this.Map = new int[height, width];
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    this.Map[i, j] = baseMap.Dequeue();
            this.Intervals = this.GetIntervals().ToList();
        }
        public IEnumerable<Interval> GetIntervals()
        {
            int start = 0;
            for (int i = 0; i < Height; i++)
            {
                if (GetColumn(i).Any(x => x == 0))
                {
                    var column = GetColumn(i).ToList();
                    int count = 0;
                    for (int j = 0; j < column.Count; j++)
                    {
                        if (column[j] == 0)
                            count++;
                        if (count > 0 && column[j] == 1)
                        {
                            yield return new Interval(start, j - count);
                            this.Wide = count;
                            count = 0;
                            start = j;
                        }
                    }
                    yield return new Interval(start, Height);
                    break;
                }
            }
        }
        public int Middle => Intervals.Skip(1).First().End - Intervals.Skip(1).First().Start;
        public IEnumerable<Position> GetNotePositions()
        {
            int max = Middle * 2;
            int lastFound = 0;
            for (int i = 0; i < Width; i++)
            {
                if (GetColumn(i).Any(x => x == 0))
                {
                    var column = GetColumn(i).ToList();
                    int count = 0;
                    bool top = false;
                    for (int j = 0; j < column.Count; j++)
                    {
                        if (column[j] == 0)
                        {
                            if (count == 0 && Intervals.Any(x => (j > x.Start && j - Wide < x.Start) || (j + Wide > x.End && j < x.End)))
                                top = true;
                            count++;
                        }
                        if (count > 0 && column[j] == 1)
                        {
                            if (count > max && lastFound + Wide < j)
                            {
                                lastFound = j;
                                yield return new Position(top ? j - count : j, i, top);
                            }
                            count = 0;
                        }
                    }
                }
            }
        }
        static List<string> Notes = new List<string> { "A", "G", "F", "E", "D", "C", "B", "A", "G", "F", "E", "D", "C" };
        public string GetNote(Position note)
        {
            for (int i = 0; i < Intervals.Count; i++)
            {
                Interval interval = Intervals[i];
                if (note.X > interval.End)
                    continue;
                else
                {
                    if (note.X > interval.Start && note.X - Wide < interval.Start)
                    {
                        return Notes[i * 2];
                    }
                    else if (note.X + Wide > interval.End)
                    {
                        return Notes[i * 2 + 2];
                    }
                    else
                    {
                        return Notes[i * 2 + 1];
                    }
                }
            }
            return string.Empty;
        }
        public IEnumerable<string> Translate()
        {
            int middle = Middle;
            foreach (Position position in this.GetNotePositions())
            {
                string note = GetNote(position);
                List<int> row = GetRow(position.X).ToList();
                bool isOpen = false;
                bool firstAttempt = true;
                for (int i = position.X - 1; i >= 0; i--)
                {
                    if (row[i] == 0 && firstAttempt)
                    {

                    }
                    else
                    {
                        firstAttempt = false;
                        if (row[i] == 0)
                        {
                            int distance = position.X - 1 - i;
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (row[k] == 0)
                                    distance++;
                                else
                                    break;
                            }
                            if (distance == middle)
                                isOpen = false;
                            break;
                        }
                    }
                }
                if (!isOpen)
                {
                    firstAttempt = true;
                    for (int i = position.X + 1; i < Width; i++)
                    {
                        if (row[i] == 0 && firstAttempt)
                        {

                        }
                        else
                        {
                            firstAttempt = false;
                            if (row[i] == 0)
                            {
                                int distance = i - position.X;
                                for (int k = i + 1; k < Width; k++)
                                {
                                    if (row[k] == 0)
                                        distance++;
                                    else
                                        break;
                                }
                                if (position.Top)
                                {
                                    if (Map[position.X - distance / 2 + 1, position.Y + distance / 2] == 0)
                                        isOpen = true;
                                    Map[position.X - distance / 2 + 1, position.Y + distance / 2] = 4;
                                }
                                else
                                {
                                    if (Map[position.X + distance / 2 - 1, position.Y + distance / 2] == 0)
                                        isOpen = true;
                                    Map[position.X - distance / 2 - 1, position.Y + distance / 2] = 4;
                                }
                                break;
                            }
                        }
                    }
                }
                yield return $"{note}{(isOpen ? "H" : "Q")}";
            }
        }
        public IEnumerable<int> GetColumn(int x)
        {
            for (int i = 0; i < Height; i++)
                yield return this.Map[i, x];
        }
        public IEnumerable<int> GetRow(int y)
        {
            for (int j = 0; j < Width; j++)
                yield return this.Map[y, j];
        }
        public void Print()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    Console.Write(this.Map[i, j]);
                Console.WriteLine(string.Empty);
            }
        }
    }
}