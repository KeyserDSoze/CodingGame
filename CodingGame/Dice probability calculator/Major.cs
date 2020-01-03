using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dice_probability_calculator
{
    internal class Major : Operation
    {
        public override char[] Operations => new char[1] { '>' };
    }
}
