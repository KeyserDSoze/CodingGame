using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Chained_Matrix_Products
{
    internal class Matrix
    {
        public int Width { get; }
        public int Height { get; }
        public Matrix(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        public static (Matrix Matrix, int Multiplications) operator *(Matrix a, Matrix b)
            => (new Matrix(a.Width, b.Height), a.Width * a.Height * b.Height);
        public override string ToString()
            => $"{this.Width} {this.Height}";
    }
}
