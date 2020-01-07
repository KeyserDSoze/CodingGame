using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Easy._1D_Bush_Fire
{
    internal class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>()
        {
            "....f....f..",
            ".......fff"
        };
        public void Run()
        {
            int N = Inputs.Count;
            List<Bush> bushes = new List<Bush>();
            for (int i = 0; i < N; i++)
            {
                string line = Inputs[i];
                Console.Error.WriteLine(line);
                bushes.Add(new Bush(line));
            }
            foreach (Bush bush in bushes)
                Console.WriteLine(bush.Solve());
        }
    }
}
