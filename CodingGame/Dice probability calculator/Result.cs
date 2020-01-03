using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Dice_probability_calculator
{
    internal class AggregatedResult : Result
    {
        public List<Result> Values { get; set; }
    }
    internal class Result
    {
        public int Value { get; set; }
    }
}
