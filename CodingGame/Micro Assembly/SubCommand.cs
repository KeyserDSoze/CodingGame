using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal class SubCommand : IInterpreter
    {
        public string Input { get; }
        public SubCommand(string input) => this.Input = input;
        public void Solve(Dictionary<string, int> values)
        {

        }
    }
}
