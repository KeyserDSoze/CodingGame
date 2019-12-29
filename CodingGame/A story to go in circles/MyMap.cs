using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.A_story_to_go_in_circles
{
    internal class MyMap
    {
        public int Width { get; }
        public int Angle { get; private set; } = 0;
        public long Start { get; }
        public string Lines => AllAngles[Angle];
        private List<string> AllAngles = new List<string>();
        private List<string> Array;
        public MyMap(List<string> lines, int width, long start)
        {
            this.Start = start;
            this.Width = width;
            this.Array = lines;
            AllAngles.Add(string.Join("", lines));
            foreach (string s in this.Array)
                Console.Error.WriteLine(s);
            AllAngles.Add(Rotate());
            AllAngles.Add(Rotate());
            AllAngles.Add(Rotate());
            Rotate();
        }
        private string Rotate()
        {
            char[,] array = new char[Width, Width];
            for (int k = 0; k < Width / 2; k++)
            {
                for (int i = 0; i < Width; i++)
                {
                    array[k, i] = this.Array[Width - i - 1][k];
                    array[i, k] = this.Array[Width - k - 1][i];
                    array[Width - k - 1, i] = this.Array[Width - i - 1][Width - k - 1];
                    array[i, Width - k - 1] = this.Array[k][i];
                }
            }
            if (Width % 2 == 1)
                array[Width / 2, Width / 2] = this.Array[Width / 2][Width / 2];
            this.Array = new List<string>();
            Console.Error.WriteLine("");
            Console.Error.WriteLine("Rotation");
            Console.Error.WriteLine("");
            for (int i = 0; i < Width; i++)
            {
                string a = "";
                for (int j = 0; j < Width; j++)
                {
                    a += array[i, j];
                }
                this.Array.Add(a);
                Console.Error.WriteLine(a);
            }
            return string.Join("", this.Array);
        }
        public void Rotate(int hourly)
        {
            this.Angle += hourly;
            if (this.Angle < 0)
                this.Angle = 3;
            if (this.Angle > 3)
                this.Angle = 0;
        }

        public MyIterator GetIterator() => new MyIterator(this);
    }
}
