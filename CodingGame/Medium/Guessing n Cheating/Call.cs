using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Guessing_n_Cheating
{
    internal class Call
    {
        private static int Ids = 1;
        public int Id { get; }
        public CallType CallType { get; }
        public int Value { get; }
        public Call(string value)
        {
            string[] kl = value.Split(' ');
            this.Value = int.Parse(kl[0]);
            if (kl[1] == "right")
                this.CallType = CallType.Winning;
            else
                this.CallType = kl[2] == "low" ? CallType.TooLow : CallType.TooHigh;
            this.Id = Ids;
            Ids++;
        }
    }
    internal enum CallType
    {
        TooHigh,
        TooLow,
        Winning
    }
}
