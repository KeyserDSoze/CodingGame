using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Count_as_I_count
{
    internal class Solution : ICodinGame
    {
        public void Run()
        {
            int n = 38;
            if (n < 2 || n >= 50)
            {
                Console.WriteLine("0");
            }
            else if (n == 49)
            {
                Console.WriteLine("1");
            }
            else
            {
                Console.Error.WriteLine(n);
                List<Result> results = new List<Result>();
                for (int round = 1; round <= 4; round++)
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        if (round > 1)
                        {
                            List<Result> morePossibilities = new List<Result>();
                            foreach (Result result in results.Where(x => !x.Won))
                            {
                                if (result.Shoots.Count < round)
                                    result.NewShoot(i);
                                else
                                {
                                    Result result1 = new Result(n, result.Shoots.First());
                                    foreach (int shoot in result.Shoots.Skip(1).Take(result.Shoots.Count - 2))
                                        result1.NewShoot(shoot);
                                    result1.NewShoot(i);
                                    morePossibilities.Add(result1);
                                }
                            }
                            results.AddRange(morePossibilities);
                        }
                        else if (n + i <= 50)
                        {
                            results.Add(new Result(n, i));
                        }
                    }
                }

                // Write an action using Console.WriteLine()
                // To debug: Console.Error.WriteLine("Debug messages...");
                Console.Error.WriteLine(string.Join(",", results.Where(x => x.Won)));
                Console.WriteLine(results.Where(x => x.Won).Sum(x => x.Combination));
            }
        }
    }
}
