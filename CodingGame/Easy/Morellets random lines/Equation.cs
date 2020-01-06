using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Morellets_random_lines
{
    internal class Equation
    {
        public float A { get; }
        public float B { get; }
        public float C { get; }
        public float M { get; }
        public float K { get; }
        public bool SolveUnderX { get; } = true;
        public Equation(float a, float b, float c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            if (b != 0)
            {
                this.M = -a / b;
                this.K = -c / b;
            }
            else
            {
                this.SolveUnderX = false;
                this.K = -c / a;
            }
        }
        public Status IsBeneath(Point p)
        {
            if (this.SolveUnderX)
            {
                float y = this.SolveWithX(p);
                if (p.Y < y)
                    return Status.Under;
                else if (p.Y == y)
                    return Status.Lies;
            }
            else
            {
                float x = this.SolveWithY(p);
                if (p.X < x)
                    return Status.Under;
                else if (p.X == x)
                    return Status.Lies;
            }
            return Status.Over;
        }
        public bool IsLinearlyIndependent(Equation equation)
        {
            if (equation.A > this.A)
                return Check(equation.A, this.A) && Check(equation.B, this.B) && Check(equation.K, this.K);
            else
                return Check(this.A, equation.A) && Check(this.B, equation.B) && Check(this.K, equation.K);
        }
        private bool Check(float a0, float a1)
        {
            bool check = false;
            if (a1 == 0 && a1 == a0)
                check = true;
            else if (a1 != 0 && a0 % a1 == 0)
                check = true;
            return check;
        }
        public float SolveWithX(Point point)
            => this.M * point.X + this.K;
        public float SolveWithY(Point point)
            => this.M * point.Y + this.K;
        public override string ToString() 
            => $"{this.A} {this.B} {this.C} {this.M} {this.K}";
    }
    internal enum Status
    {
        Under,
        Over,
        Lies
    }
}
