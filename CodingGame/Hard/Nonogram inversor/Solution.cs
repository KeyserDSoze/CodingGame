using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Hard.Nonogram_inversor
{
    class Solution : ICodinGame
    {
        List<string> Inputs = new List<string>()
        {
            "5 5",
            "1",
            "3",
            "2",
            "5",
            "1",
            "1",
            "1 3",
            "3",
            "1 1",
            "1 1",
        };

        public void Run()
        {
            string[] inputs = Inputs[0].Split(' ');
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            for (int i = 0; i < width; i++)
            {
                string blackGroups = Inputs[i + 1];
            }
            for (int i = 0; i < height; i++)
            {
                string blackGroups = Inputs[i + width + 1];
            }
        }
    }
}
