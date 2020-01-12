using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CodinGame.Medium.OneWay_City
{
    class Solution : ICodinGame
    {
        static int M = 71;
        static int N = 75;
        public void Run()
        {
            string value = GetValue(M, N).ToString();
            Console.WriteLine(value.Length > 1000 ? value.Substring(0, 1000) : value);
            //BigNumber a = new BigNumber(999);
            //BigNumber b = new BigNumber(99);
            //Console.Error.WriteLine(a > b);
            //Console.Error.WriteLine(a < b);
            //Console.Error.WriteLine(a.Factorial(b));
            //Console.Error.WriteLine(a / b);
        }
        static BigInteger GetValue(int width, int height)
        {
            int min = (width > height ? height : width) - 1;
            int max = (width > height ? width : height) - 1;
            return (width + height - 2).Factorial(max) / min.Factorial();
        }
        static BigNumber GetValue(int width, int height, bool tro)
        {
            BigNumber min = new BigNumber((width > height ? height : width) - 1);
            BigNumber max = new BigNumber((width > height ? width : height) - 1);
            return new BigNumber(width + height - 2).Factorial(max) / min.Factorial();
        }
    }
    static class IntExtensions
    {
        public static BigInteger Factorial(this int x, int min = 0)
        {
            BigInteger result = 1;
            for (int i = 2; i <= x; i++)
            {
                if (i > min)
                    result *= i;
            }
            return result;
        }
    }
}
