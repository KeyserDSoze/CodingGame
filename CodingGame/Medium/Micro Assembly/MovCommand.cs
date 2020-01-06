using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal class MovCommand : IInterpreter
    {
        public string[] Input { get; }
        public MovCommand(string input) => this.Input = input.Split(' ');
        public int Solve(Dictionary<string, int> values)
        {
            string a = this.Input[1];
            string b = this.Input[2];
            if (values.ContainsKey(a))
                values[a] = values.ContainsKey(b) ? values[b] : int.Parse(b);
            return -1;
        }
    }
}
