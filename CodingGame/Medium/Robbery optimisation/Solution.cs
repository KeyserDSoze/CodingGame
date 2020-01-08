using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Robbery_optimisation
{
    internal class Solution : ICodinGame
    {
        private static List<long> Inputs = new List<long>()
        {
           2,5,2,10,8,4,5,2
        };
        public void Run()
        {
            int N = Inputs.Count;
            List<long> houses = new List<long>();
            for (int i = 0; i < N; i++)
            {
                long housevalue = Inputs[i];
                houses.Add(housevalue);
            }
            int count = 0;
            long money = 0;
            while (count < N)
            {
                //long maxA = 0;
                //long maxB = 0;
                //long maxC = 0;
                //if (count + 3 < N)
                //{
                //    maxA = houses[count] + houses[count + 2];
                //    maxB = houses[count] + houses[count + 3];
                //}
                int maxCount = count + 3;
                long max = 0;
                for (int i = count; i < N && i < maxCount; i++)
                {
                    if (houses[i] > max)
                    {
                        max = houses[i];
                        count = i + 2;
                    }
                }
                if (max == 0)
                    count += 3;
                else
                    money += max;
            }
            Console.WriteLine(money);
        }
    }
}
