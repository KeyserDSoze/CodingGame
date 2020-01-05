using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal class AddCommand : OperationCommand
    {
        public AddCommand(string input) : base(input, '+') { }
    }
}
