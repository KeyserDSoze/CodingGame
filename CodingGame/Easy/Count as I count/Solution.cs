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
            Console.WriteLine("Insert value");
            int n = int.Parse(Console.ReadLine());
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
                for (int i = 1; i <= 12; i++)
                    for (int j = 0; j <= 12; j++)
                        for (int k = 0; k <= 12; k++)
                            for (int z = 0; z <= 12; z++)
                                if (n + i + j + k + z == 50)
                                    results.Add(new Result(n, i, j, k, z));
                //Console.Error.WriteLine(string.Join(", ", results.Where(x => x.Won)));
                results = results.Distinct(new ResultComparer()).ToList();
                string a = '\n'.ToString();
                Console.Error.WriteLine(string.Join(a, results.Where(x => x.Won)));
                Console.WriteLine(results.Where(x => x.Won).Sum(x => x.Combination));
            }
        }
    }
}
