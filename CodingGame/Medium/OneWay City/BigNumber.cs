using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.OneWay_City
{
    internal class BigNumber
    {
        public int[] Value { get; }
        public int this[int x] => this.Value[x];
        public int Length
        {
            get
            {
                for (int i = 0; i < this.Value.Length; i++)
                    if (this.Value[i] > 0)
                        return this.Value.Length - i;
                return 0;
            }
        }
        public BigNumber(int value, int max = 1000)
        {
            this.Value = new int[max];
            for (int i = max - 1; i >= 0; i--)
            {
                int remainder = value % 10;
                this.Value[i] = remainder;
                value = value / 10;
                if (value == 0)
                    break;
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool firstValue = false;
            for (int i = 0; i < this.Value.Length; i++)
                if (firstValue || (firstValue = this.Value[i] > 0))
                    stringBuilder.Append(this.Value[i]);
            string value = stringBuilder.ToString();
            return value == string.Empty ? "0" : value;
        }
        public static BigNumber Zero => new BigNumber(0);
        public static BigNumber One => new BigNumber(1);
        public BigNumber Factorial(BigNumber min = null)
        {
            if (min == null)
                min = new BigNumber(2);
            BigNumber c = new BigNumber(1);
            BigNumber last = this + One;
            for (BigNumber i = min; i < last; i += One)
                c *= i;
            return c;
        }
        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            BigNumber c = new BigNumber(0);
            int next = 0;
            for (int i = b.Value.Length - 1; i >= 0; i--)
            {
                int value = a[i] + b[i] + next;
                int remainder = value % 10;
                c.Value[i] = remainder;
                next = value / 10;
            }
            return c;
        }
        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            BigNumber c = new BigNumber(0);
            int next = 0;
            for (int i = b.Value.Length - 1; i >= 0; i--)
            {
                int value = a[i] - b[i] - next;
                if (value < 0)
                {
                    value += 10;
                    next = 1;
                }
                else
                    next = 0;
                c.Value[i] = value;
            }
            return c;
        }
        public static bool operator <(BigNumber a, BigNumber b)
        {
            int aLength = a.Length;
            int bLength = b.Length;
            if (aLength < bLength)
                return true;
            else if (aLength > bLength)
                return false;
            else
            {
                for (int i = b.Length; i >= 0; i--)
                {
                    int aValue = a[a.Value.Length - 1 - i];
                    int bValue = b[b.Value.Length - 1 - i];
                    if (aValue < bValue)
                        return true;
                    else if (aValue > bValue)
                        return false;
                }
                return false;
            }
        }
        public static bool operator >(BigNumber a, BigNumber b)
        {
            int aLength = a.Length;
            int bLength = b.Length;
            if (aLength > bLength)
                return true;
            else if (aLength < bLength)
                return false;
            else
            {
                for (int i = b.Length; i >= 0; i--)
                {
                    int aValue = a[a.Value.Length - 1 - i];
                    int bValue = b[b.Value.Length - 1 - i];
                    if (aValue > bValue)
                        return true;
                    else if (aValue < bValue)
                        return false;
                }
                return false;
            }
        }
        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            BigNumber c = new BigNumber(0);
            int aLength = a.Length;
            int bLength = b.Length;
            int[] indexes = new int[aLength];
            for (int i = 0; i < aLength; i++)
                indexes[i] = -1 * i;
            int next = 0;
            int round = a.Length + b.Length;
            for (int i = 0; i < round; i++)
            {
                int value = next;
                for (int j = 0; j < aLength; j++)
                {
                    if (indexes[j] >= 0 && indexes[j] < bLength)
                        value += a[a.Value.Length - 1 - j] * b[b.Value.Length - 1 - indexes[j]];
                    indexes[j]++;
                }
                int remainder = value % 10;
                c.Value[c.Value.Length - 1 - i] = remainder;
                next = value / 10;
            }
            return c;
        }
        public static BigNumber operator /(BigNumber a, BigNumber b)
        {
            int count = 0;
            BigNumber c = a;
            while(c > b)
            {
                c -= b;
                count++;
            }
            return new BigNumber(count + 1);
        }
    }
}
