using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Next_car_license_plate
{
    internal class Solution : ICodinGame
    {
        public void Run()
        {
            const int n = 10000;
            const string x = "CG-007-CG";
            LicensePlate licensePlate = new LicensePlate(x);
            for (int i = 0; i < n; i++)
                licensePlate.PlusPlus();
            Console.WriteLine(licensePlate);
        }
    }
}
