using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dice_probability_calculator
{
    internal class MultiplyDivider : Operation
    {
        public override char[] Operations => new char[2] { '*', '/' };
    }
}
