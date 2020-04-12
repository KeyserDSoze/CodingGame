using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace CodinGame.Medium.Fun_with_Set_theory
{
    internal class Sets
    {
        private Dictionary<int, List<int>> Values = new Dictionary<int, List<int>>();
        private string Input;
        private static readonly Regex Numbers = new Regex(@"\{[^\}]*\}");
        private static readonly Regex SquareLeftRight = new Regex(@"\[[0-9;\-]*\]");
        private static readonly Regex SquareRight = new Regex(@"\][0-9;\-]*\]");
        private static readonly Regex SquareLeft = new Regex(@"\[[0-9;\-]*\[");
        private static readonly Regex Square = new Regex(@"\][0-9;\-]*\[");
        private static readonly Regex Operations = new Regex("[UI-]{1}");
        private int Id = 0;
        public Sets(string input)
            => Install(input);
        public List<int> Interpret()
        {
            while (this.Input.Contains("("))
                Replace(GetParenthesis(this.Input), "({0})");
            Replace(this.Input, "{0}");
            return this.Values[int.Parse(this.Input)];
        }
        private void Replace(string output, string replacer)
        {
            int[] values = Operations.Split(output).Select(x => int.Parse(x)).ToArray();
            List<char> operations = new List<char>();
            foreach (var v in Operations.Matches(output))
                operations.Add(v.ToString()[0]);
            for (int i = 0; i < values.Length - 1; i++)
                this.Operate(values[i], values[i + 1], operations[i]);
            this.Input = this.Input.Replace(string.Format(replacer, output), values.Last().ToString());
        }
        private void Operate(int a, int b, char operation)
        {
            List<int> value = this.Values[a];
            switch (operation)
            {
                case 'U':
                    value = value.Union(this.Values[b]).ToList();
                    break;
                case 'I':
                    value = value.Intersect(this.Values[b]).ToList();
                    break;
                case '-':
                    foreach (var s in this.Values[b])
                        value.Remove(s);
                    break;
            }
            this.Values[b] = value;
        }
        private string GetParenthesis(string value)
        {
            StringBuilder returnValue = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '(')
                    returnValue = new StringBuilder();
                else if (value[i] == ')')
                    return returnValue.ToString();
                else
                    returnValue.Append(value[i].ToString());
            }
            return returnValue.ToString();
        }
        private void Install(string input)
        {
            this.Input = input;
            foreach (var x in Numbers.Matches(this.Input))
            {
                this.Values.Add(Id, x.ToString().Trim('{').Trim('}').Split(';').Select(t => int.Parse(t)).ToList());
                this.Input = this.Input.Replace(x.ToString(), Id.ToString());
                Id++;
            }
            SetSquare(SquareLeftRight, 0, 0);
            SetSquare(SquareLeft, 0, 1);
            SetSquare(SquareRight, 1, 0);
            SetSquare(Square);
        }
        private void SetSquare(Regex regex, int skipStart = 1, int skipEnd = 1)
        {
            foreach (var x in regex.Matches(this.Input))
            {
                string result = x.ToString();
                if (result.Length == 3 && result[1] == '-')
                    continue;
                string[] y = result.Trim(']').Trim('[').Split(';');
                List<int> yy = new List<int>();
                for (int i = int.Parse(y[0]) + skipStart; i <= int.Parse(y[1]) - skipEnd; i++)
                    yy.Add(i);
                this.Values.Add(Id, yy);
                this.Input = this.Input.Replace(result, Id.ToString());
                Id++;
            }
        }
    }
}
