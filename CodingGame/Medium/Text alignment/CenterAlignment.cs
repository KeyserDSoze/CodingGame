using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Text_alignment
{
    class CenterAlignment : IAlignment
    {
        public string Align(string text, int max)
        {
            return new string(' ', (max - text.Length) / 2) + text;
        }
    }
}
