using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dice_probability_calculator
{
    internal class AddSubtracter : Operation
    {
        public override char[] Operations => new char[2] { '+', '-' };
    }
}
