using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Sudoku_Solver
{
    internal class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>()
        {
            "120070560",
            "507932080",
            "000001000",
            "010240050",
            "308000402",
            "070085010",
            "000700000",
            "080423701",
            "034010028",
        };
        public void Run()
        {
            Sudoku sudoku = new Sudoku();
            for (int i = 0; i < 9; i++)
            {
                string line = Inputs[i];
                sudoku.AddLine(line, i);
            }
            sudoku.SetPossibleValues();
            List<Cell> solutions = sudoku.Solve();
            sudoku.Draw();
        }
    }
}
