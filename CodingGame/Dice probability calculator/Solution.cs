using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Dice_probability_calculator
{
    internal class Solution : ICodinGame
    {
        static string expr = "2*d6*d3-(3+d3)*d5>0";
        public void Run()
        {
            List<string> entryPoint = new List<string>() { expr };
            List<string> exitPoint = Executor.Instance.Calculate(entryPoint);
            foreach (var result in exitPoint.GroupBy(x => x).Select(x => new { Value = x.Key, Count = (float)x.Count() }))
            {
                Console.WriteLine($"{result.Value} {(result.Count * 100 / (float)exitPoint.Count).ToString("N2")}");
            }
        }
    }
}
