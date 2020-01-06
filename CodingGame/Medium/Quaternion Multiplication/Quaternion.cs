using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodinGame.Medium.Quaternion_Multiplication
{
    internal struct Quaternion
    {
        public int I { get; }
        public int J { get; }
        public int K { get; }
        public int C { get; }
        public Quaternion(string a) : this(0, 0, 0, 0)
        {
            string value = string.Empty;
            for (int i = 0; i < a.Length; i++)
            {
                value += a[i];
                if ((i > 0 || i == a.Length - 1) && (a[i] == '+' || a[i] == '-' || i == a.Length - 1))
                {
                    if (a[i] == '+' || a[i] == '-')
                        value = value.TrimEnd(a[i]);
                    switch (value[value.Length - 1])
                    {
                        case 'i':
                            if (value == "i")
                                this.I = 1;
                            else if (value == "-i")
                                this.I = -1;
                            else
                                this.I = int.Parse(value.Trim('i'));
                            break;
                        case 'j':
                            if (value == "j")
                                this.J = 1;
                            else if (value == "-j")
                                this.J = -1;
                            else
                                this.J = int.Parse(value.Trim('j'));
                            break;
                        case 'k':
                            if (value == "k")
                                this.K = 1;
                            else if (value == "-k")
                                this.K = -1;
                            else
                                this.K = int.Parse(value.Trim('k'));
                            break;
                        default:
                            this.C = int.Parse(value);
                            break;
                    }
                    value = a[i] == '-' ? a[i].ToString() : string.Empty;
                }
            }
        }
        public Quaternion(int i, int j, int k, int c)
        {
            this.I = i;
            this.J = j;
            this.K = k;
            this.C = c;
        }
        public static Quaternion operator *(Quaternion a, Quaternion b)
        {
            int i = a.J * b.K - a.K * b.J + a.I * b.C + a.C * b.I;
            int j = a.K * b.I - a.I * b.K + a.J * b.C + a.C * b.J;
            int k = a.I * b.J - a.J * b.I + a.K * b.C + a.C * b.K;
            int c = a.C * b.C - a.I * b.I - a.J * b.J - a.K * b.K;
            return new Quaternion(i, j, k, c);
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (this.I != 0)
                stringBuilder.Append($"{(this.I == 1 ? string.Empty : this.I.ToString())}i");
            if (this.J != 0)
                stringBuilder.Append($"{(this.J > 0 ? "+" : string.Empty)}{(this.J == 1 ? string.Empty : this.J.ToString())}j");
            if (this.K != 0)
                stringBuilder.Append($"{(this.K > 0 ? "+" : string.Empty)}{(this.K == 1 ? string.Empty : this.K.ToString())}k");
            if (this.C != 0)
                stringBuilder.Append($"{(this.C > 0 ? "+" : string.Empty)}{this.C}");
            return stringBuilder.ToString().Trim('+').Replace("-1i", "-i").Replace("-1j", "-j").Replace("-1k", "-k");
        }
    }
}
