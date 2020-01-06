using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Dice_probability_calculator
{
    public abstract class Operation : IOperation
    {
        private static string Number = "0123456789d";
        public abstract char[] Operations { get; }
        public virtual Dictionary<string, int> Calculate(Dictionary<string, int> expressions)
        {
            for (int j = 0; j < expressions.Count; j++)
            {
                var keyPair = expressions.ElementAt(j);
                bool containing = false;
                foreach (char c in Operations)
                    containing |= keyPair.Key.Contains(c);
                if (containing)
                {
                    for (int i = 0; i < keyPair.Key.Length; i++)
                    {
                        if (Operations.Contains(keyPair.Key[i]))
                        {
                            string firstNumber = string.Empty;
                            string secondNumber = string.Empty;
                            for (int k = i - 1; k >= 0; k--)
                                if (Number.Contains(keyPair.Key[k]))
                                    firstNumber = $"{keyPair.Key[k]}{firstNumber}";
                                else if (k == 0 && keyPair.Key[k] == '-')
                                    firstNumber = $"-{firstNumber}";
                                else
                                    break;
                            for (int k = i + 1; k < keyPair.Key.Length; k++)
                                if (Number.Contains(keyPair.Key[k]))
                                    secondNumber = $"{secondNumber}{keyPair.Key[k]}";
                                else
                                    break;
                            if (!string.IsNullOrWhiteSpace(firstNumber))
                            {
                                List<decimal> results = this.GetResult(firstNumber, secondNumber, keyPair.Key[i]);
                                if (results.Count > 0)
                                {
                                    string key = $"{firstNumber}{keyPair.Key[i]}{secondNumber}";
                                    foreach (decimal result in results)
                                    {
                                        string newKey = keyPair.Key.Replace(key, result.ToString());
                                        if (!expressions.ContainsKey(newKey))
                                            expressions.Add(newKey, keyPair.Value);
                                        else
                                            expressions[newKey] += keyPair.Value;
                                    }
                                    expressions.Remove(keyPair.Key);
                                    j = -1;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return expressions;
        }
        private List<decimal> GetResult(string left, string right, char operation)
        {
            List<decimal> results = new List<decimal>();
            int startI = 1;
            int startJ = 1;
            int endI = 1;
            int endJ = 1;
            if (left.Contains("d"))
                endI = int.Parse(left.Trim('d'));
            else
                startI = endI = int.Parse(left);
            if (right.Contains("d"))
                endJ = int.Parse(right.Trim('d'));
            else
                startJ = endJ = int.Parse(right);
            for (decimal i = startI; i <= endI; i++)
                for (decimal j = startJ; j <= endJ; j++)
                    results.Add(GetResult(i, j, operation));
            return results;
        }
        private decimal GetResult(decimal left, decimal right, char operation)
        {
            switch (operation)
            {
                case '+':
                    return left + right;
                case '-':
                    return left - right;
                case '*':
                    return left * right;
                case '/':
                    return left / right;
                case '>':
                    return left > right ? 1 : 0;
                default:
                    throw new ArgumentException($"Operation {operation} is not implemented.");
            }
        }
    }
}
