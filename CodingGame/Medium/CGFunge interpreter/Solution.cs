using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.CGFunge_interpreter
{
    internal class Solution : ICodinGame
    {
        private static List<string> Inputs = new List<string>()
        {
            "39DD1+*+DI  >11091+   v>v",
            " v  \" on the wall\"    < D ",
            ">>     \"reeb fo\"      v S",
            "0v<\" bottles \"        < C",
            "X>DSC_SvPD      _25*+Cv |",
            "       *v   IS        < P",
            "^IDX-1 <>  SC        0v X",
            "v   \"pass it around\"  < 1",
            ">    \" ,nwod eno ekat\" ^-",
            " Sing it!   ^+55D-1X_ESD<",
        };
        public void Run()
        {
            List<string> lines = new List<string>();
            int N = Inputs.Count;
            int maxValue = 0;
            for (int i = 0; i < N; i++)
            {
                string line = Inputs[i];
                lines.Add(line);
                if (line.Length > maxValue)
                    maxValue = line.Length;
            }
            for (int i = 0; i < N; i++)
            {
                lines[i] = lines[i] + new string((char)0, maxValue - lines[i].Length);
            }

            Executor executer = new Executor();
            executer.Solve(lines);
        }
    }
}
