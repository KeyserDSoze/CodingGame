using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Easy._1D_Bush_Fire
{
    internal class Bush
    {
        public string Input { get; }
        public Bush(string input) => this.Input = input;
        public int Solve()
        {
            int count = 0;
            int fireFound = 0;
            for (int i = 0; i < this.Input.Length; i++)
            {
                if (this.Input[i] == 'f' && fireFound == 0)
                {
                    fireFound = 1;
                    count++;
                }
                else if (fireFound > 0)
                {
                    fireFound++;
                }
                if (fireFound == 3)
                {
                    fireFound = 0;
                }
            }
            return count;
        }
    }
}
