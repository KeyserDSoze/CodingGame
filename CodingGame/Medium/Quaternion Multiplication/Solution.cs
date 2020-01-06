using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodinGame.Medium.Quaternion_Multiplication
{
    //http://mathworld.wolfram.com/Quaternion.html
    internal class Solution : ICodinGame
    {
        private static Regex Regex = new Regex(@"\([^\)]*\)");
        private static string Value = "(10i)(10j-k+1)(-99i+j-10k+7)(4)";
        public void Run()
        {
            Queue<Quaternion> quaternions = new Queue<Quaternion>();
            foreach (Match match in Regex.Matches(Value))
            {
                quaternions.Enqueue(new Quaternion(match.Value.Trim('(').Trim(')')));
            }
            Quaternion result = quaternions.Dequeue();
            while (quaternions.Count > 0)
            {
                result *= quaternions.Dequeue();
            }
            Console.WriteLine(result);
        }
    }
}
