using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Snake_encoding
{
    internal class Solution : ICodinGame
    {
        static int N = 3;
        static int X = 1;
        static List<string> Inputs = new List<string>()
        {
            "ABC",
            "DEF",
            "GHI"
        };
        public void Run()
        {
            char[,] map = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                string LINE = Inputs[i];
                for (int j = 0; j < N; j++)
                    map[i, j] = LINE[j];
            }
            for (int i = 0; i < X; i++)
                map = map.Tranform();
            map.ToResult();
        }
    }
    internal static class ArrayExtensions
    {
        public static char[,] Tranform(this char[,] array)
        {
            int n = array.GetLength(1);
            char[,] newArray = new char[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    char value = array[i, j];
                    if ((n % 2 == 0 && i == n - 1 && j == n - 1) || (n % 2 == 1 && i == 0 && j == n - 1))
                        newArray[n - 1, 0] = value;
                    else if (j % 2 == 0)
                    {
                        if (i == 0)
                            newArray[i, j + 1] = value;
                        else
                            newArray[i - 1, j] = value;
                    }
                    else
                    {
                        if (i == n - 1)
                            newArray[i, j + 1] = value;
                        else
                            newArray[i + 1, j] = value;
                    }
                }
            }
            return newArray;
        }
        public static void ToResult(this char[,] array)
        {
            int n = array.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                string line = "";
                for (int j = 0; j < n; j++)
                    line += array[i, j];
                Console.WriteLine(line);
            }
        }
    }
}
