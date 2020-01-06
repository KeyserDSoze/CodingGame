using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    class JneCommand : IInterpreter
    {
        public string[] Input { get; }
        public JneCommand(string input) => this.Input = input.Split(' ');
        public int Solve(Dictionary<string, int> values)
        {
            string a = this.Input[1];
            string b = this.Input[2];
            string c = this.Input[3];
            int aVal = values.ContainsKey(b) ? values[b] : int.Parse(b);
            int bVal = values.ContainsKey(c) ? values[c] : int.Parse(c);
            if (aVal != bVal)
                return int.Parse(a);
            else
                return -1;
        }
    }
}
