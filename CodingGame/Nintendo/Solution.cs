using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Nintendo
{
    internal class Solution : ICodinGame
    {
        static string Input = "00000001 000073af";
        static int S = 32;
        public void Run()
        {
            Encoding encoding = new Encoding(Input, S);
            encoding.Encrypt();
        }
    }
}
