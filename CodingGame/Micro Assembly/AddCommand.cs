using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal class AddCommand : IInterpreter
    {
        public string Input { get; }
        public AddCommand(string input) => this.Input = input;
        public void Solve(Dictionary<string, int> values)
        {

        }
    }
}
