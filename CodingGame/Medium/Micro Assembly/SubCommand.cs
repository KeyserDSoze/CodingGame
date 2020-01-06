using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal class SubCommand : OperationCommand
    {
        public SubCommand(string input) : base(input, '-') { }
    }
}
