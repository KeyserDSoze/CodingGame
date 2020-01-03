using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodinGame.Dice_probability_calculator
{
    public static class Executor
    {
        public static Computer Instance { get; } = new Computer();
    }
    public class Computer : IOperation
    {
        private static readonly List<IOperation> Operations = new List<IOperation>();
        static Computer()
        {
            Operations.Add(new Parenthesis());
            Operations.Add(new MultiplyDivider());
            Operations.Add(new AddSubtracter());
            Operations.Add(new Major());
        }
        private static readonly Regex dice = new Regex("d[0-9]{1-2}");
        public List<string> Calculate(List<string> context)
        {
            foreach (IOperation operation in Operations)
                context = operation.Calculate(context);
            return context;
        }
    }
}
