using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.CodeGolf.PowerOfThor
{
    internal class Solution : ICodinGame
    {
        static string t = "7 8 28 8";
        public void Run()
        {
            var w = t.Split(' ').Select(x => int.Parse(x)).ToList();
            var a = G(w[3] - w[1], 'N', 'S');
            var b = G(w[2] - w[0], 'W', 'E');
            while (true)
                Console.WriteLine($"{L(a)}{L(b)}".Trim());
        }
        static Queue<char> G(int x, char a, char b) => new Queue<char>(new string(x > 0 ? a : b, Math.Abs(x)).ToCharArray());
        static char L(Queue<char> q) => q.Count > 0 ? q.Dequeue() : ' ';
    }
}
