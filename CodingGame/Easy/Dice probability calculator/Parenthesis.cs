using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodinGame.Dice_probability_calculator
{
    internal class Parenthesis : Operation
    {
        private static readonly char[] operations = new char[2] { '(', ')' };
        public override char[] Operations => operations;
        private static readonly Regex Regex = new Regex(@"\([^\)]*\)");
        public override Dictionary<string, int> Calculate(Dictionary<string, int> finalEntry)
        {
            for (int j = 0; j < finalEntry.Count; j++)
            {
                var keyValue = finalEntry.ElementAt(j);
                if (keyValue.Key.Contains(Operations[0]))
                {
                    StringBuilder match = null;
                    for (int i = 0; i < keyValue.Key.Length; i++)
                    {
                        if (keyValue.Key[i] == Operations[0])
                            match = new StringBuilder();
                        else if (keyValue.Key[i] == Operations[1])
                            break;
                        else if (match != null)
                            match.Append(keyValue.Key[i]);
                    }
                    string value = match.ToString();
                    Dictionary<string, int> results = Executor.Instance.Calculate(new Dictionary<string, int>() { { value.Trim('(').Trim(')'), keyValue.Value } });
                    foreach (KeyValuePair<string, int> result in results)
                    {
                        finalEntry.Add(keyValue.Key.Replace($"({value})", result.Key), result.Value);
                    }
                    if (results.Count > 0)
                    {
                        finalEntry.Remove(keyValue.Key);
                        j--;
                    }
                }
            }
            return finalEntry;
        }
    }
}
