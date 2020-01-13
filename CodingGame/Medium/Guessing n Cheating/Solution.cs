using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Guessing_n_Cheating
{
    class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>()
        {
            "50 too low",
            "52 too high",
            "51 too low",
            "52 too low",
            "50 too high",
            "53 right on",
        };
        static List<ICheat> Cheats = new List<ICheat>()
        {
            new Distance(),
            new Edge(),
            new AlreadySaid(),
            new Victory(),
        };
        public void Run()
        {
            int R = Inputs.Count;
            List<Call> calls = new List<Call>();
            Call victory = null;
            for (int i = 0; i < R; i++)
            {
                string line = Inputs[i];
                if (i < R - 1)
                    calls.Add(new Call(line));
                else
                    victory = new Call(line);
            }
            int round = int.MaxValue;
            foreach (ICheat cheat in Cheats)
            {
                int value = cheat.Check(calls, victory);
                if (value > 0 && value < round)
                    round = value;
            }
            if (round != int.MaxValue)
                Console.WriteLine($"Alice cheated in round {round}");
            else
                Console.WriteLine("No evidence of cheating");
        }
    }
}
