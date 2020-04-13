using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Palindromic_Decomposition
{
    internal class Solution : ICodinGame
    {
        private const string Input = "abab";
        public void Run()
        {
            string S = Input;
            Console.WriteLine(Counts(S));
        }
        public static int Counts(string input)
        {
            int count = 0;
            for (int i = 0; i <= input.Length; i++)
            {
                string a = input.Substring(0, i);
                if (a.IsPalindrome())
                {
                    string newValue = input.Substring(i);
                    for (int j = 0; j <= newValue.Length; j++)
                    {
                        string b = newValue.Substring(0, j);
                        if (b.IsPalindrome())
                        {
                            string c = newValue.Substring(j);
                            if (c.IsPalindrome())
                                count++;
                        }
                    }
                }
            }
            return count;
        }
    }
    internal static class StringExtensions
    {
        public static bool IsPalindrome(this string value)
        {
            int middle = value.Length / 2;
            if (middle == 0)
                return true;
            for (int i = 0; i < middle; i++)
                if (value[i] != value[value.Length - i - 1])
                    return false;
            return true;
        }
    }
}
