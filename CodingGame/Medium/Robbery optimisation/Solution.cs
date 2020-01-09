using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodinGame.Medium.Robbery_optimisation
{
    internal class Solution : ICodinGame
    {
        private static List<long> Inputs = new List<long>()
        {
           //2,5,10,2,4,8,5,2,6,7,7,6,11,12,5,9,6,10,7,9,17,63,121,12,85,95,60,100,70,91,73,26,41,28,58,19,26,17,7,9,11,23,21,42,68,65,86,101,106,1
           1,15,10,13,16

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
            
            Console.WriteLine(GetMoney(houses));
        }
        public static long GetMoney(List<long> houses) 
        {
            long currentMax = 0;
            long previousMax = 0;
            for (int i = 0; i < houses.Count; i++)
            {
                long currentHouse = houses[i];
                long newMax = Math.Max(currentMax, previousMax + currentHouse);
                previousMax = currentMax;
                currentMax = newMax;
            }
            return currentMax;
        }
    }
}
