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
                    try
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
                                foreach (decimal result in results)
                                    expressions.Add(expressions[j].Replace($"{firstNumber}{expressions[j][i]}{secondNumber}", result.ToString()));
                                if (results.Count > 0)
                                {
                                    expressions.RemoveAt(j);
                                    j--;
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        string a = "";
                    }
                }
            }
            return expressions;
        }
        private List<decimal> GetResult(string left, string right, char operation)
        {
            List<decimal> results = new List<decimal>();
            if (left.Contains("d") && right.Contains("d"))
            {
                decimal rightValue = decimal.Parse(right.Replace("d", ""));
                decimal leftValue = decimal.Parse(left.Replace("d", ""));
                if (operation == '*')
                    for (decimal j = 1; j <= leftValue * rightValue; j++)
                        results.Add(j);
                else
                    for (decimal i = 1; i <= leftValue; i++)
                        for (decimal j = 1; j <= rightValue; j++)
                            results.Add(GetResult(i, j, operation));
            }
            else if (left.Contains("d"))
            {
                decimal rightValue = decimal.Parse(right);
                decimal leftValue = decimal.Parse(left.Replace("d", ""));
                if (operation == '*')
                    for (decimal i = rightValue; i <= leftValue * rightValue; i++)
                        results.Add(i);
                else
                    for (decimal i = 1; i <= leftValue; i++)
                        results.Add(GetResult(rightValue, i, operation));
            }
            else if (right.Contains("d"))
            {
                decimal rightValue = decimal.Parse(right.Replace("d", ""));
                decimal leftValue = decimal.Parse(left);
                if (operation == '*')
                    for (decimal i = leftValue; i <= leftValue * rightValue; i++)
                        results.Add(i);
                else
                    for (decimal i = 1; i <= rightValue; i++)
                        results.Add(GetResult(leftValue, i, operation));
            }
            else
                results.Add(GetResult(decimal.Parse(left), decimal.Parse(right), operation));

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
