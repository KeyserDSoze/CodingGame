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
        //static string expr = "2*d6*d3-(3+d3)*d5>0";
        //static string expr = "2*d3-4*d5>0";
        //static string expr = "d9-2*d4";
        static string expr = "8>d6+d6";

        public void Run()
        {
            Dictionary<string, int> exitPoint = Executor.Instance.Calculate(new Dictionary<string, int>() { { expr, 1 } });
            int total = exitPoint.Sum(x => x.Value);
            foreach (var result in exitPoint.OrderBy(x => int.Parse(x.Key)))
            {
                Console.WriteLine($"{result.Key} {((float)result.Value * 100 / (float)total).ToString("N2")} {result.Value}");
            }
        }
    }
}
