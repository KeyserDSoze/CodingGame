using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal class InterpreterFactory
    {
        public static IInterpreter Interprete(string instruction)
        {
            switch (instruction.Split(' ')[0])
            {
                case "MOV":
                    return new MovCommand(instruction);
                case "ADD":
                    return new AddCommand(instruction);
                case "SUB":
                    return new SubCommand(instruction);
                case "JNE":
                    return new JneCommand(instruction);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
