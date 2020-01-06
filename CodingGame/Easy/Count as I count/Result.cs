using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Count_as_I_count
{
    internal class Result
    {
        public int X { get; private set; }
        public List<int> Shoots { get; } = new List<int>();
        private List<List<int>> Combinations = new List<List<int>>();
        public int Combination
        {
            get
            {
                int combination = GetCombination(this.Shoots);
                foreach (List<int> shoots in this.Combinations)
                    combination += GetCombination(shoots);
                return combination;
            }
        }
        private int GetCombination(List<int> values)
        {
            Dictionary<int, int> counted = new Dictionary<int, int>();
            foreach (int x in values)
            {
                if (!counted.ContainsKey(x))
                    counted.Add(x, 0);
                counted[x]++;
            }
            int divisor = 1;
            foreach (var x in counted)
                divisor *= Factorial(x.Value);
            return Factorial(values.Count) / divisor;
        }
        private int Factorial(int value)
        {
            int result = 1;
            for (int i = 2; i <= value; i++)
                result *= i;
            return result;
        }
        public bool Won => this.X == 50;
        public Result(int n, int x)
        {
            this.X = n + x;
            this.Shoots.Add(x);
        }
        public Result(int n, params int[] values)
        {
            this.X = n + values.Sum();
            foreach (int x in values)
                if (x > 0)
                    this.Shoots.Add(x);
            for (int i = 0; i < this.Shoots.Count; i++)
            {
                if (this.Shoots[i] > 1)
                {
                    List<int> shoots = new List<int>();
                    foreach (int shoot in this.Shoots)
                        shoots.Add(shoot);
                    for (int j = i; j < shoots.Count; j++)
                        if (shoots[j] > 1)
                        {
                            shoots[j] += 40;
                            List<int> internalShoots = new List<int>();
                            foreach (int shoot in shoots)
                                internalShoots.Add(shoot);
                            this.Combinations.Add(internalShoots);
                        }
                }
            }
            this.Combinations = this.Combinations.Distinct(new ListedComparer()).ToList();
        }
        public void NewShoot(int x)
        {
            if (this.X + x <= 50)
            {
                this.Shoots.Add(x);
                this.X += x;
            }
        }
        public override string ToString()
            => $"{string.Join("|", this.Shoots)} ({this.GetCombination(this.Shoots)}) -- [{string.Join(",[", this.Combinations.Select(t => string.Join(",", t) + $"] ({this.GetCombination(t)})"))} ==> ({this.Combination})";
    }
    internal class ResultComparer : IEqualityComparer<Result>
    {
        public bool Equals(Result x, Result y)
        {
            return string.Join("|", x.Shoots.OrderBy(z => z)) == string.Join("|", y.Shoots.OrderBy(z => z));
        }

        public int GetHashCode(Result obj)
        {
            int returned = obj.Shoots.First();
            foreach (int x in obj.Shoots.Skip(1))
                returned ^= x;
            return returned;
        }
    }
    internal class ListedComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            return string.Join("|", x.OrderBy(z => z)) == string.Join("|", y.OrderBy(z => z));
        }

        public int GetHashCode(List<int> obj)
        {
            int returned = obj.First();
            foreach (int x in obj.Skip(1))
                returned ^= x;
            return returned;
        }
    }
}
