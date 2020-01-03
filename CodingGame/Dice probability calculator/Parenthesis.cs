using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodinGame.Dice_probability_calculator
{
    internal class Parenthesis : Operation
    {
        private static readonly char[] operations = new char[2] { '(', ')' };
        public override char[] Operations => operations;
        private static readonly Regex Regex = new Regex(@"\([^\)]*\)");
        public override List<string> Calculate(List<string> finalEntry)
        {
            for (int j = 0; j < finalEntry.Count; j++)
            {
                if (finalEntry[j].Contains(Operations[0]))
                {
                    StringBuilder match = null;
                    for (int i = 0; i < finalEntry[j].Length; i++)
                    {
                        if (finalEntry[j][i] == Operations[0])
                            match = new StringBuilder();
                        else if (finalEntry[j][i] == Operations[1])
                            break;
                        else if (match != null)
                            match.Append(finalEntry[j][i]);
                    }
                    string value = match.ToString();
                    List<string> results = Executor.Instance.Calculate(new List<string>() { value.Trim('(').Trim(')') });
                    foreach (string result in results)
                        finalEntry.Add(finalEntry[j].Replace($"({value})", result));
                    if (results.Count > 0)
                    {
                        finalEntry.RemoveAt(j);
                        j--;
                    }
                }
            }
            return finalEntry;
        }
    }
}
