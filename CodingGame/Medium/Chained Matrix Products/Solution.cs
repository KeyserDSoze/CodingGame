using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Chained_Matrix_Products
{
    class Solution : ICodinGame
    {
        static List<string> Inputs = new List<string>()
        {
            "5 10",
            "10 6",
            "6 30",
            "30 4",
            "4 12",
            "12 16",
        };
        public void Run()
        {
            int N = Inputs.Count;
            List<Matrix> matrix = new List<Matrix>();
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Inputs[i].Split(' ');
                int row = int.Parse(inputs[0]);
                int col = int.Parse(inputs[1]);
                matrix.Add(new Matrix(row, col));
            }
            Console.WriteLine(GetMinimum(matrix));
        }
        
        private static int GetMinimum(List<Matrix> matrices)
        {
            int multiplication = 0;
            while (matrices.Count > 1)
            {
                int min = int.MaxValue;
                int index = -1;
                for (int i = 0; i < matrices.Count - 1; i++)
                {
                    int value = matrices[i].Width * matrices[i].Height * matrices[i + 1].Height;
                    if (value < min)
                    {
                        min = value;
                        index = i;
                    }
                }
                matrices[index] = (matrices[index] * matrices[index + 1]).Matrix;
                matrices.RemoveAt(index + 1);
                multiplication += min;
            }
            return multiplication;
        }
    }
}
