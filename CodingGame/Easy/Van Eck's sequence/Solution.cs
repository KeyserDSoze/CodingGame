using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Easy.Van_Eck_s_sequence
{
    internal class Solution : ICodinGame
    {
        static int[] Input = new int[2] { 0, 1000000 };
        public void Run()
        {
            int A1 = Input[0];
            int N = Input[1];

            Console.WriteLine(new Series(A1, N).Last());
        }
    }
}
