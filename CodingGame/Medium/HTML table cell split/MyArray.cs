using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.HTML_table_cell_split
{
    internal class MyArray<T> : IEnumerable<T>, IEnumerable
    {
        private class Wrapper<T>
        {
            public T Entity { get; }
            public int X { get; }
            public int Y { get; }
            public Wrapper(T t, int x, int y)
            {
                this.Entity = t;
                this.X = x;
                this.Y = y;
            }
        }
        public MyArray() { }
        public MyArray(int initialHeight, int initialWidth)
        {
            for (int i = 0; i < initialHeight; i++)
                for (int j = 0; j < initialWidth; j++)
                    this.Add(default, i, j);
        }
        private Dictionary<string, Wrapper<T>> Map = new Dictionary<string, Wrapper<T>>();
        public IEnumerator<T> GetEnumerator() => new MyArrayEnumerator<T>(this);
        IEnumerator IEnumerable.GetEnumerator()
            => new MyArrayEnumerator<T>(this);
        public T this[int x, int y] => this.Map[this.Key(x, y)].Entity;
        public IEnumerable<T> this[int x] => this.Map.Select(ƒ => ƒ.Value).Where(ƒ => ƒ.X == x).Select(x => x.Entity);
        public IEnumerable<T> this[int y, bool onY] => this.Map.Select(ƒ => ƒ.Value).Where(ƒ => ƒ.Y == y).Select(x => x.Entity);
        public bool HasValue(int x, int y = 0) => this.Map.ContainsKey(this.Key(x, y)) && this.Map[this.Key(x, y)] != null;
        private Dictionary<int, int> width = new Dictionary<int, int>();
        public int Length => width.Count;
        public int Width(int x) => width.ContainsKey(x) ? width[x] : 0;
        public int MaxWidth => width.Select(x => x.Value).OrderByDescending(x => x).FirstOrDefault();
        private string Key(int x, int y) => $"{x}-{y}";
        public void Add(T value)
            => this.Add(value, this.Length > 0 ? this.Length - 1 : 0);
        public void Add(T value, int x)
            => this.Add(value, x, this.Width(x) > 0 ? this.Width(x) - 1 : 0);
        public void Add(T value, int x, int y)
        {
            this.Map.Add(this.Key(x, y), new Wrapper<T>(value, x, y));
            if (!width.ContainsKey(x))
                width.Add(x, 0);
            width[x]++;
        }
        public void AddOrUpdate(T value)
            => this.AddOrUpdate(value, this.Length > 0 ? this.Length - 1 : 0);
        public void AddOrUpdate(T value, int x)
            => this.AddOrUpdate(value, x, this.Width(x) > 0 ? this.Width(x) - 1 : 0);
        public void AddOrUpdate(T value, int x, int y)
        {
            string key = this.Key(x, y);
            if (!this.Map.ContainsKey(key))
            {
                this.Map.Add(key, new Wrapper<T>(value, x, y));
                if (!width.ContainsKey(x))
                    width.Add(x, 0);
                width[x]++;
            }
            else
                this.Map[key] = new Wrapper<T>(value, x, y);
        }
    }
    internal class MyArrayEnumerator<T> : IEnumerator<T>, IEnumerator
    {
        private int X;
        private int Y;
        private MyArray<T> MyArray;
        public MyArrayEnumerator(MyArray<T> myArray) => this.MyArray = myArray;
        public T Current => this.MyArray[this.X, this.Y];
        object IEnumerator.Current => this.MyArray[this.X, this.Y];
        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.Y < this.MyArray.Width(this.X))
                this.Y++;
            else
            {
                this.Y = 0;
                if (this.X < this.MyArray.Length)
                    this.X++;
                else
                    return false;
            }
            return true;
        }

        public void Reset()
        {
            this.X = 0;
            this.Y = 0;
        }
    }
}
