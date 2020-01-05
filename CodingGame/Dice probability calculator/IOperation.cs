using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dice_probability_calculator
{
    internal interface IOperation
    {
        Dictionary<string, int> Calculate(Dictionary<string, int> expression);
    }
}
