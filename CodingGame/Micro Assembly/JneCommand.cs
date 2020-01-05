using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    class JneCommand : IInterpreter
    {
        public string Input { get; }
        public JneCommand(string input) => this.Input = input;
        public void Solve(Dictionary<string, int> values)
        {

        }
    }
}
