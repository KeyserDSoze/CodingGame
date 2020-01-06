using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.AreTheClumpsNormal
{
    internal class SingleNumber
    {
        public List<int> Numbers { get; } = new List<int>();
        public int Count => this.Numbers.Count;

        public int IsValid()
        {
            for (int inBase = 2; inBase < 10; inBase++)
            {
                int remainder = this.Numbers.First() % inBase;
                for (int i = 1; i < this.Count; i++)
                    if (this.Numbers[i] % inBase != remainder)
                        return inBase;
            }
            return 1;
        }
        public bool IsValid(int inBase)
        {
            if (this.Numbers.Count == 1)
                return false;
            int remainderPair = this.Numbers.First() % inBase;
            int remainderOdd = this.Numbers.Skip(1).First() % inBase;
            for (int i = 2; i < this.Count; i++)
            {
                if (i % 2 == 0) 
                {
                    if (this.Numbers[i] % inBase != remainderPair)
                        return false;
                    remainderPair = this.Numbers[i] % inBase;
                }
                else 
                {
                    if (this.Numbers[i] % inBase != remainderOdd)
                        return false;
                    remainderOdd = this.Numbers[i] % inBase;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return string.Join(",", this.Numbers);
        }
    }
}
