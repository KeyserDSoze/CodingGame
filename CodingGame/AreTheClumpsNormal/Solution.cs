using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.AreTheClumpsNormal
{
    internal class Solution : ICodinGame
    {
        static long N = 157285;
        public void Run()
        {
            TheNumber theNumber = new TheNumber(N.ToString());
            for (int i = 2; i < 10; i++)
            {
                SingleNumber value = theNumber.Pairs.OrderBy(x => x.Numbers.Count).FirstOrDefault(x => x.IsValid(i));
                Console.Error.WriteLine(value);
                Console.Error.WriteLine(string.Empty);
                Console.Error.WriteLine(string.Empty);
            }
        }
    }
}
