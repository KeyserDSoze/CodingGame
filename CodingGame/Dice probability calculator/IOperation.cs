using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dice_probability_calculator
{
    internal interface IOperation
    {
        List<string> Calculate(List<string> expression);
    }
}
