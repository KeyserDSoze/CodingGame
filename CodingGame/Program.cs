using System;
using System.Collections.Generic;
using System.Text;
using CodingGame.DetectivePikaptchaEp2;

namespace CodingGame
{
    class Program
    {
        
        static void Main(string[] args)
        {
            (bool, int) returned = ShadowsOfTheKnightEp2.ShadowsMain.Start();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine($"In {returned.Item2} steps");
            Console.WriteLine(returned.Item1);
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
