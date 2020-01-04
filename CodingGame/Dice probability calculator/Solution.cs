using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Dice_probability_calculator
{
    internal class Solution : ICodinGame
    {
        //static string expr = "12-d2*d6";
        //static string expr = "d9-2*d4";
        static string expr = "2*d6*d3-(3+d3)*d5>0";
        //static string expr = "d9-2*d4";

        public void Run()
        {
            List<string> entryPoint = new List<string>() { expr };
            List<string> exitPoint = Executor.Instance.Calculate(entryPoint);
            foreach (var result in exitPoint.OrderBy(x => int.Parse(x)).GroupBy(x => x).Select(x => new { Value = x.Key, Count = (float)x.Count() }))
            {
                Console.WriteLine($"{result.Value} {(result.Count * 100 / (float)exitPoint.Count).ToString("N2")} {result.Count}");
            }
        }
    }
}
