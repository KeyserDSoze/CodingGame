using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Count_as_I_count
{
    internal class Result
    {
        public int X { get; private set; }
        public List<int> Shoots { get; } = new List<int>();
        public int Combination
        {
            get
            {
                int combination = GetCombination(this.Shoots);
                for (int i = 0; i < this.Shoots.Count; i++)
                {
                    List<int> shoots = new List<int>();
                    foreach (int shoot in Shoots)
                        shoots.Add(shoot);
                    for (int j = i; j < shoots.Count; j++)
                    {
                        if (shoots[j] > 1)
                        {
                            shoots[j] += 40;
                            combination += GetCombination(shoots);
                        }
                    }
                }
                return combination;
            }
        }
        private int GetCombination(List<int> values)
        {
            Dictionary<int, int> counted = new Dictionary<int, int>();
            foreach (int x in this.Shoots)
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
        public void NewShoot(int x)
        {
            if (this.X + x <= 50)
            {
                this.Shoots.Add(x);
                this.X += x;
            }
        }
        public override string ToString()
            => $"{this.X} {string.Join("|",this.Shoots)}";
    }
}
