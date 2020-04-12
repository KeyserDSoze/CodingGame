using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodinGame.Medium.Fun_with_Set_theory
{
    public class Solution : ICodinGame
    {
        private const string Input = "{2;3;1}";

        public void Run()
        {
            Sets sets = new Sets(Input);
            string result = string.Join(" ", sets.Interpret().OrderBy(x => x));
            Console.WriteLine(!string.IsNullOrWhiteSpace(result) ? result : "EMPTY");
        }
    }
    
}
