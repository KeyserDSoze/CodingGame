﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Factorial_vs_Exponential
{
    class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>()
        {
           "3027.64",
            "4734.53",
            "2306",
            "4316.74",
            "8091.79",
            "4385.96",
            "4827",
            "2811",
            "637.86",
            "7584.03",
            "6471",
            "9751.4",
            "662",
            "6590",
            "2227.08",
            "3006",
            "1450",
            "3876.51",
            "6503.87",
            "5029",
            "8968",
            "8161",
            "7743",
            "6146.37",
            "7705.2",
            "191.38",
            "8412",
            "7968.66",
            "6349.78",
            "5197",
            "3792",
            "5640.61",
            "2191",
            "4057",
            "7511.5",
            "75.71",
            "9716",
            "2338",
            "5359.63",
            "4196",
            "1812",
            "1497",
            "6500",
            "5265.09",
            "7861",
            "5994.93",
            "5212",
            "4687",
            "7350.89",
            "6615",
            "7840.03",
            "2046.5",
            "5702",
            "3069",
            "1574",
            "2783",
            "6864.35",
            "5444",
            "3843",
            "7986.35",
            "2514",
            "94",
            "1343.43",
            "6928",
            "1581",
            "8429",
            "2684",
            "2226.15",
            "7182.02",
            "1517.36",
            "6527.87",
            "7380.3",
            "324",
            "3870",
            "3349",
            "5935",
            "2108",
            "1512.28",
            "7593",
            "2642",
            "2671.62",
            "29.97",
            "530.35",
            "96",
            "5305",
            "2241",
            "3117",
            "2415",
            "1016.67",
            "2277.83",
            "4269",
            "5471",
            "1195.57",
            "1018",
            "5434.34",
            "9266.84",
            "4872.7",
            "2785",
            "935.94",
            "4895.59",
        };
        public void Run()
        {
            int K = Inputs.Count;
            List<float> floats = new List<float>();
            for (int i = 0; i < K; i++)
            {
                float A = float.Parse(Inputs[i]);
                floats.Add(A);
            }
            string result = string.Empty;
            foreach (float a in floats)
            {
                int start = (int)a + 1;
                result += $"{WhenIsGreater(a, start * 2)} ";
            }
            Console.WriteLine(result.Trim());
        }
        public static int WhenIsGreater(float a, int n)
        {
            const double threshold = 200000;
            double result = a;
            int next = n;
            List<int> integers = new List<int>();
            for (int i = n; i >= 2; i--)
                integers.Add(i);
            while (integers.Count > 0)
            {
                int i = result < 1 ? integers.Last() : integers.First();
                result *= a / i;
                integers.Remove(i);
                while (result > threshold)
                {
                    next++;
                    result *= a / next;
                }
            }
            while (result > 1)
            {
                next++;
                result *= a / next;
            }
            return next;
        }
    }
}
