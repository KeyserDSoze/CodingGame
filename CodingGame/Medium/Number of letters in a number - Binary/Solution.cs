using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Number_of_letters_in_a_number___Binary
{
    internal class Solution : ICodinGame
    {
        public void Run()
        {
            const long start = 99999999999999999;
            const long n = 99999999999999999;
            Phrase phrase = new Phrase(start);
            long last = long.MinValue;
            for (long i = 0; i < n - 1; i++)
            {
                phrase = phrase.Next();
                if (last == phrase.Value)
                    break;
                last = phrase.Value;
            }
            Console.WriteLine(phrase.Value);
        }
    }
}
