using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodinGame.Medium.Text_alignment
{
    class JustifyAlignment : IAlignment
    {
        public string Align(string text, int max)
        {
            string[] words = text.Split(' ');
            int count = max - text.Length;
            int spaces = count / words.Length + 1;
            int remainder = count % words.Length - 1;
            string newText = "";
            for (int i = 0; i < words.Length; i++)
            {
                newText += $"{words[i]}{(i < words.Length - 1 ? new string(' ', spaces) : string.Empty)}{(remainder > -1 && i < words.Length - 1 && i <= remainder + 1 ? " " : string.Empty)}";
            }
            return newText;
        }
    }
}
