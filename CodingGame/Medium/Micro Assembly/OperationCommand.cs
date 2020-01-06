using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal abstract class OperationCommand : IInterpreter
    {
        public string[] Input { get; }
        public char Operation { get; }
        public OperationCommand(string input, char operation)
        {
            this.Input = input.Split(' ');
            this.Operation = operation;
        }
        public int Solve(Dictionary<string, int> values)
        {
            string a = this.Input[1];
            string b = this.Input[2];
            string c = this.Input[3];
            if (values.ContainsKey(a))
            {
                values[a] = Calculate(values.ContainsKey(b) ? values[b] : int.Parse(b),
                    values.ContainsKey(c) ? values[c] : int.Parse(c));
            }
            return -1;
        }
        private int Calculate(int a, int b)
        {
            switch (this.Operation)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
