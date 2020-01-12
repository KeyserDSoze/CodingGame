using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace CodinGame.Medium.Factorial_vs_Exponential
{
    class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>()
        {
            "36",
            "57.64",
            "92.73",
            "14.95",
            "49",
            "11",
            "6",
            "76.9",
            "93.83",
            "80",
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
                bool greater = IsGreater(a, start);
                while (!greater)
                {
                    start++;
                    greater = IsGreater(a, start);
                }
                result += $"{start} ";
            }
            Console.WriteLine(result.Trim());
        }
        public static bool IsGreater(float a, int n)
            => Pow(a, n) < Factorial(n);
        public static BigInteger Pow(float a, int n)
        {
            BigInteger result = new BigInteger(a);
            BigInteger aa = new BigInteger(a);
            for (int i = 0; i < n - 1; i++)
            {
                result *= aa;
            }
            return result;

        }
        public static BigInteger Factorial(int n)
        {
            BigInteger product = 1;
            for (int i = 2; i <= n; i++)
                product *= i;
            return product;
        }
    }
}
