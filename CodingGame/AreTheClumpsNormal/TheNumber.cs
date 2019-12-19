using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.AreTheClumpsNormal
{
    internal class TheNumber
    {
        public List<SingleNumber> Pairs { get; } = new List<SingleNumber>();

        public TheNumber(string value)
        {
            List<string> values = new List<string>();
            for (int k = 0; k < value.Length; k++)
            {
                string startNumber = value[k].ToString();
                List<int> numbers = new List<int>();
                for (int i = 0; i < k; i++)
                    numbers.Add(int.Parse(value[i].ToString()));
                for (int i = k; i < value.Length; i++)
                {
                    SingleNumber number = new SingleNumber();
                    foreach (int n in numbers)
                        number.Numbers.Add(n);
                    number.Numbers.Add(int.Parse($"{startNumber}{value.Substring(k + 1, i - k)}"));
                    for (int j = i + 1; j < value.Length; j++)
                    {
                        number.Numbers.Add(int.Parse(value[j].ToString()));
                    }
                    if (!values.Contains(number.ToString()))
                    {
                        this.Pairs.Add(number);
                        values.Add(number.ToString());
                    }
                }
            }
            Pairs = Pairs.Distinct().ToList();
        }
    }
}
