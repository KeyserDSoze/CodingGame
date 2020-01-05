using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal class MovCommand : IInterpreter
    {
        public string Input { get; }
        public MovCommand(string input) => this.Input = input;
        public void Solve(Dictionary<string, int> values)
        {
            string[] inputs = this.Input.Split(' ');
            string a = inputs[1];
            string b = inputs[2];
            if (values.ContainsKey(a))
                values[a] = values.ContainsKey(b) ? values[b] : int.Parse(b);
        }
    }
}
