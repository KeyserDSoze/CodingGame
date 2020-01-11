using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Text_alignment
{
    internal class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>()
        {
            "Never gonna give you up, never gonna let you down",
            "Never gonna run around and desert you",
            "Never gonna make you cry, never gonna say goodbye",
            "Never gonna tell a lie and hurt you",
        };
        static string alignment = "JUSTIFY";
        public void Run()
        {
            int N = Inputs.Count;
            List<string> values = new List<string>();
            for (int i = 0; i < N; i++)
            {
                string text = Inputs[i];
                values.Add(text);
            }
            AlignmentFactory alignmentFactory = new AlignmentFactory();
            IAlignment aligner = alignmentFactory.Create(alignment);
            int max = values.Select(x => x.Length).Max();
            foreach (string v in values)
            {
                Console.WriteLine(aligner.Align(v, max));
            }
        }
    }
}
