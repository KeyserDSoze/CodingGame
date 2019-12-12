using System;
using System.Collections.Generic;
using System.Text;
using CodinGame.DetectivePikaptchaEp2;

namespace CodinGame
{
    class Program
    {
        private static readonly CodinGame CodinGame = new CodinGame("CodinGame");
        static void Main(string[] args)
        {
            CodinGame.Start();
        }
    }
    static class Player 
    {
        internal static void Log(object o) => Console.WriteLine(o);
    }
    static class Solution 
    {
        internal static void Log(object o) => Player.Log(o);
    }
}
