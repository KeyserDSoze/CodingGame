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
        public virtual List<string> Calculate(List<string> expressions)
        {
            for (int j = 0; j < expressions.Count; j++)
            {
                for (int i = 0; i < expressions[j].Length; i++)
                {
                    if (Operations.Contains(expressions[j][i]))
                    {
                        string firstNumber = string.Empty;
                        string secondNumber = string.Empty;
                        for (int k = i - 1; k >= 0; k--)
                            if (Number.Contains(expressions[j][k]))
                                firstNumber = $"{expressions[j][k]}{firstNumber}";
                            else if (k == 0 && expressions[j][k] == '-')
                                firstNumber = $"-{firstNumber}";
                            else
                                break;
                        for (int k = i + 1; k < expressions[j].Length; k++)
                            if (Number.Contains(expressions[j][k]))
                                secondNumber = $"{secondNumber}{expressions[j][k]}";
                            else
                                break;
                        if (!string.IsNullOrWhiteSpace(firstNumber))
                        {
                            List<decimal> results = this.GetResult(firstNumber, secondNumber, expressions[j][i]);
                            if (results.Count > 0)
                            {
                                int count = expressions.Count;
                                for (int l = 0; l < count; l++)
                                {
                                    List<string> newly = new List<string>();
                                    foreach (decimal result in results)
                                        newly.Add(expressions[l].Replace($"{firstNumber}{expressions[j][i]}{secondNumber}", result.ToString()));
                                    if (newly.Count > 0)
                                    {
                                        expressions.AddRange(newly);
                                        expressions.RemoveAt(l);
                                        l--;
                                        count--;
                                    }
                                }
                                j--;
                                break;
                            }
                        }
                    }
                }
            }
            return expressions;
        }
        private static Dictionary<string, List<decimal>> CalculatedResults = new Dictionary<string, List<decimal>>();
        private List<decimal> GetResult(string left, string right, char operation)
        {
            string key = $"{left}{operation}{right}";
            if (CalculatedResults.ContainsKey(key))
                return CalculatedResults[key];
            List<decimal> results = new List<decimal>();
            if (left.Contains("d") && right.Contains("d"))
            {
                decimal rightValue = decimal.Parse(right.Replace("d", ""));
                decimal leftValue = decimal.Parse(left.Replace("d", ""));
                for (decimal i = 1; i <= leftValue; i++)
                    for (decimal j = 1; j <= rightValue; j++)
                        results.Add(GetResult(i, j, operation));
            }
            else if (left.Contains("d"))
                results = GetFinalResult(decimal.Parse(right), decimal.Parse(left.Replace("d", "")), operation);
            else if (right.Contains("d"))
                results = GetFinalResult(decimal.Parse(left), decimal.Parse(right.Replace("d", "")), operation);
            else
                results.Add(GetResult(decimal.Parse(left), decimal.Parse(right), operation));
            CalculatedResults.Add(key, results);
            return results;
        }
        private List<decimal> Multiply(int count, int max)
        {
            List<decimal> multiplications = new List<decimal>();
            for (int i = 1; i <= max; i++)
                for (int j = 1; j <= max; j++)
                    multiplications.Add(i + j);
            for (int j = 3; j <= count; j++)
            {
                List<decimal> newMultiplications = new List<decimal>();
                foreach (decimal multiplication in multiplications)
                    for (int i = 1; i <= max; i++)
                        newMultiplications.Add(multiplication + i);
                multiplications = newMultiplications;
            }
            return multiplications;
        }
        private List<decimal> GetFinalResult(decimal first, decimal second, char operation)
        {
            List<decimal> results = new List<decimal>();
            if (operation == '*')
            {
                results = Multiply((int)first, (int)second);
            }
            else
                for (decimal i = 1; i <= second; i++)
                    results.Add(GetResult(first, i, operation));
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
