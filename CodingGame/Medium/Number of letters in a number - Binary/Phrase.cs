using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Number_of_letters_in_a_number___Binary
{
    internal class Phrase
    {
        public int Value { get; }
        public Phrase(long value)
        {
            foreach (char c in Convert.ToString(value, 2))
                this.Value += c == '0' ? 4 : 3;
        }
        public Phrase Next() 
            => new Phrase(this.Value);
    }
}
