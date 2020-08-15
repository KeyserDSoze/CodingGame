using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Easy.TicTacToe
{
    class Solution : ICodinGame
    {
        string[] Lines = new string[3]
        {
            "O..",
            "...",
            "O..",
        };
        public void Run()
        {
            Map map = new Map();
            for (int i = 0; i < 3; i++)
            {
                string line = Lines[i];
                map.AddRow(line);
            }
            map.SetWinning();
            foreach (string solution in map.GetSolution())
                Console.WriteLine(solution);
        }
    }
}
