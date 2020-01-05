using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal class Solution : ICodinGame
    {
        static string Numbers = "1 2 3 -4";
        static List<string> Commands = new List<string>()
        {
            "MOV b 3",
            "MOV c a"
        };
        public void Run()
        {
            string[] inputs = Numbers.Split(' ');
            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);
            int c = int.Parse(inputs[2]);
            int d = int.Parse(inputs[3]);
            Dictionary<string, int> values = new Dictionary<string, int>();
            values.Add("a", a);
            values.Add("b", b);
            values.Add("c", c);
            values.Add("d", d);
            int n = Commands.Count;
            for (int i = 0; i < n; i++)
            {
                string instruction = Commands[i];
                Console.Error.WriteLine(instruction);
                IInterpreter interpreter = InterpreterFactory.Interprete(instruction);
                interpreter.Solve(values);
            }

            string response = "";
            foreach (var x in values)
                response += x.Value.ToString() + " ";
            Console.WriteLine(response.Trim());
        }
    }
}
