using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodinGame.Medium.Brackets_Extended_Edition
{
    internal class Solution : ICodinGame
    {
        static Regex Regex = new Regex(@"[^\(\)\[\]\{\}<>]*");
        const string B1d = "((";
        const string B2d = "[[";
        const string B3d = "{{";
        const string B4d = "<<";
        const char B1o = '(';
        const char B1c = ')';
        const char B2o = '[';
        const char B2c = ']';
        const char B3o = '{';
        const char B3c = '}';
        const char B4o = '<';
        const char B4c = '>';
        static List<string> Inputs = new List<string>()
        {
            "<{[(abc(]}>",
            "<{[(abc>}])"
        };
        public void Run()
        {
            int N = Inputs.Count;
            for (int j = 0; j < N; j++)
            {
                string initial = Inputs[j];
                initial = Regex.Replace(initial, string.Empty);
                initial = initial.Replace(B1c, B1o).Replace(B2c, B2o).Replace(B3c, B3o).Replace(B4c, B4o);
                Console.Error.WriteLine(initial);
                while (initial != string.Empty)
                {
                    if (initial.Contains(B1d) || initial.Contains(B2d) || initial.Contains(B3d) || initial.Contains(B4d))
                        initial = initial.Replace(B1d, string.Empty).Replace(B2d, string.Empty).Replace(B3d, string.Empty).Replace(B4d, string.Empty);
                    else
                        break;
                }
                if (initial.Length > 0)
                    Console.WriteLine("false");
                else
                    Console.WriteLine("true");
            }
        }
    }
}
