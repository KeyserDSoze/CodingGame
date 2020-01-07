using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Next_car_license_plate
{
    internal class LicensePlate
    {
        public int Number { get; private set; }
        public char[] First { get; private set; }
        public char[] Second { get; private set; }
        public LicensePlate(string value)
        {
            string[] split = value.Split('-');
            this.First = split[0].ToCharArray();
            this.Second = split[2].ToCharArray();
            this.Number = int.Parse(split[1]);
        }
        public void PlusPlus()
        {
            if (this.Number < 999)
                this.Number++;
            else
            {
                this.Number = 1;
                if (this.Second[1] < 'Z')
                    this.Second[1]++;
                else
                {
                    this.Second[1] = 'A';
                    if (this.Second[0] < 'Z')
                        this.Second[0]++;
                    else
                    {
                        this.Second[0] = 'A';
                        if (this.First[1] < 'Z')
                            this.First[1]++;
                        else
                        {
                            this.First[1] = 'A';
                            if (this.First[0] < 'Z')
                                this.First[0]++;
                        }
                    }
                }
            }
        }
        public override string ToString()
        {
            return $"{this.First[0]}{this.First[1]}-{new string('0', 3 - this.Number.ToString().Length)}{this.Number}-{this.Second[0]}{this.Second[1]}";
        }
    }
}
