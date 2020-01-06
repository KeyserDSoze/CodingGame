using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Dynamic_sorting
{
    internal class Logic
    {
        public bool Ascending { get; }
        public bool IsInteger { get; }
        public string Name { get; }
        public Logic(string value, string integer)
        {
            this.Ascending = value.Contains('+');
            this.Name = value.Trim('+').Trim('-');
            this.IsInteger = integer == "int";
        }
    }
}
