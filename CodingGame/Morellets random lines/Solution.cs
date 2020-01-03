using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Morellets_random_lines
{
    internal class Solution : ICodinGame
    {
        static int xA = -10;
        static int yA = 201;
        static int xB = 102;
        static int yB = 86;
        static List<string> Inputs = new List<string>()
        {
            "-3 5 3",
            "9 -2 10",
            "-8 -5 3",
            "7 10 -5",
            "2 -4 1",
            "-6 9 5",
            "-3 6 9",
            "2 -6 -6",
            "-4 -2 -5",
            "0 1 3",
            "5 7 10",
            "8 2 -6",
            "3 4 1",
            "-10 5 -2",
            "1 6 -9",
            "3 0 3",
            "-6 -6 -1",
            "8 7 6",
            "-9 -9 9",
            "-7 7 -6",
            "9 -10 5",
            "0 5 2",
            "-4 -1 7",
            "2 2 -5",
            "-6 -4 4",
            "0 9 -7",
            "2 -7 10",
            "10 -6 -8",
            "-5 -9 4",
            "7 -6 0",
            "-5 -2 5",
            "-4 -9 -9",
            "4 -10 1",
            "7 7 10",
            "7 -6 1",
            "1 4 2",
            "-9 -4 3",
            "-1 0 -1",
            "-5 6 -10",
            "-10 -2 6",
            "-3 10 9",
            "6 5 5",
            "-2 -7 -4",
            "-6 3 1",
            "9 -3 1",
            "8 -6 2",
            "10 -8 5",
            "7 6 5",
            "-10 -2 -8",
            "9 -7 -7",
            "7 -1 -6",
            "9 10 -2",
            "-1 6 -6",
            "-5 -10 -10",
            "0 3 -7",
            "-9 8 -9",
            "7 -8 -4",
            "-7 5 -3",
            "9 -2 10",
            "-10 -9 2",
            "4 -3 -7",
            "2 10 8",
            "9 5 4",
            "9 0 9",
            "-10 10 0",
            "8 8 10",
            "0 -5 -1",
            "5 -1 2",
            "5 3 1",
            "3 10 8",
            "10 6 -4",
            "8 -9 0",
            "6 2 5",
            "9 4 6",
            "-8 7 -8",
            "5 -3 -3",
            "-1 -6 -9",
            "-9 -1 5",
            "-1 -3 -8",
            "-4 -8 -2",
            "5 8 10",
            "5 10 -9",
            "10 4 -9",
            "-7 -7 -2",
            "7 7 -4",
            "10 7 7",
            "7 4 -1",
            "-9 7 5",
            "8 0 -4",
            "0 -10 3",
            "7 6 4",
            "2 8 -9",
            "-5 3 -3",
            "10 -4 -1",
            "1 10 -4",
            "-8 -9 7",
            "5 -8 -7",
            "-8 4 -2",
            "-5 0 5",
            "7 -3 -4"
        };
        static int n = Inputs.Count;
        public void Run()
        {
            Point pointA = new Point(xA, yA);
            Point pointB = new Point(xB, yB);
            List<Equation> lines = new List<Equation>();
            for (int i = 0; i < n; i++)
            {
                string[] inputs = Inputs[i].Split(' ');
                int a = int.Parse(inputs[0]);
                int b = int.Parse(inputs[1]);
                int c = int.Parse(inputs[2]);
                Equation line = new Equation(a, b, c);
                bool linearlyIndependent = false;
                foreach (Equation previousLine in lines)
                    linearlyIndependent |= previousLine.IsLinearlyIndependent(line);
                if (!linearlyIndependent)
                    lines.Add(line);
                Console.Error.WriteLine($"{line} count: {lines.Count}");
            }
            Console.Error.WriteLine($"");
            Console.Error.WriteLine($"");
            foreach (Equation line in lines.OrderBy(x => x.A))
                Console.Error.WriteLine($"{line}");
            int countA = 0;
            int countB = 0;
            Console.Error.WriteLine($"");
            Console.Error.WriteLine($"");
            foreach (Equation line in lines.OrderBy(x => x.A))
            {
                Status statusA = line.IsBeneath(pointA);
                Status statusB = line.IsBeneath(pointB);
                Console.Error.WriteLine($"{pointA} on {line} with status {statusA}");
                Console.Error.WriteLine($"{pointB} on {line} with status {statusB}");
                Console.Error.WriteLine($"");
                Console.Error.WriteLine($"");
                if (statusA == Status.Lies || statusB == Status.Lies)
                {
                    Console.WriteLine("ON A LINE");
                    goto End;
                }
                if (statusA == Status.Over)
                    countA++;
                if (statusB == Status.Over)
                    countB++;
            }
            Console.Error.WriteLine($"{countA} {countB}");
            Console.WriteLine(Math.Abs(countA - countB) % 2 == 0 ? "YES" : "NO");
        End: Console.Error.WriteLine("End");
        }
    }
}
