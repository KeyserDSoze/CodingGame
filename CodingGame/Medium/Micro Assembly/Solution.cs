using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal class Solution : ICodinGame
    {
        static string Numbers = "3 5 7 9";
        static List<string> Commands = new List<string>()
        {
            "SUB b b 1",
            "JNE 0 b 0",
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
            List<string> commands = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string instruction = Commands[i];
                Console.Error.WriteLine(instruction);
                commands.Add(instruction);
            }
            for (int i = 0; i < n; i++)
            {
                IInterpreter interpreter = InterpreterFactory.Interprete(commands[i]);
                int jump = interpreter.Solve(values);
                if (jump >= 0)
                    i = jump - 1;
            }
            string response = "";
            foreach (var x in values)
                response += x.Value.ToString() + " ";
            Console.WriteLine(response.Trim());
        }
    }
}
