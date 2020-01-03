using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Nintendo
{
    internal class Encoding
    {
        public string Text { get; }
        public int S { get; }
        public Encoding(string a, int s)
        {
            this.Text = a;
            this.S = s;
        }
        public void Encrypt()
        {
            int size = S / 16;
            uint[] a = new uint[size]; // <- input tab to encrypt
            uint[] b = new uint[size]; // <- output tab

            string[] inputs = this.Text.Split(' ');
            for (int i = 0; i < size; i++)
            {
                a[i] = Convert.ToUInt32(inputs[i], 16);
            }

            for (int i = 0; i < size; i++)
            {
                b[i] = 0;
            }

            for (int i = 0; i < this.S; i++)
            {
                for (int j = 0; j < this.S; j++)
                {
                    uint first2 = (a[i / 32] >> (i % 32));
                    uint first = a[i / 32] / (uint)Math.Pow(2, i % 32);
                    uint second2 = (a[j / 32 + this.S / 32] >> (j % 32));
                    uint second = a[j / 32 + this.S / 32] / (uint)Math.Pow(2, j % 32);
                    uint third2 = (first2 & second2);
                    uint fourth2 = third2 & 1;
                    uint fourth = (uint)(first % 2 == 1 && second % 2 == 1 ? 1 : 0);
                    Go(fourth);
                    int fifth = ((i + j) % 32);
                    b[(i + j) / 32] ^= fourth << fifth;   // Magic centaurian operation
                    Go(b[(i + j) / 32]);
                }
            }

            for (int i = 0; i < size; i++)
            {
                if (i > 0)
                    Console.Write(" ");
                Console.Write(b[i].ToString("X"));
            }
        }
        private void Go(uint value)
            => Console.WriteLine($"{Convert.ToString(value, 2)}");
        public void Decrypt()
        {
            int size = S / 16;
            uint[] a = new uint[size];
            uint[] b = new uint[size];
            int count = 0;
            foreach (string s in this.Text.Split(' '))
            {
                b[count] = Convert.ToUInt32(s, 16);
                count++;
            }

            for (int i = S - 1; i >= 0; i++)
            {
                for (int j = S - 1; j >= 0; j++)
                {
                    uint firstValue = b[(i + j) / 32] >> ((i + j) % 32);
                    a[(i + j) / 32] ^=
                            firstValue & 1 &
                            (b[j / 32 + S / 32] << (j % 32));   // Magic centaurian operation
                    //int fourth = b[(i + j) / 32]  ((i + j) % 32);
                }
            }
        }
    }
}
