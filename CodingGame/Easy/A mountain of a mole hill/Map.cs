using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Easy.A_mountain_of_a_mole_hill
{
    class Point
    {
        public int X { get; }
        public int Y { get; }
        public bool IsClosed { get; private set; }
        public Point(int x, int y, List<string> inputs)
        {
            this.X = x;
            this.Y = y;
            this.CheckFence2(inputs);
        }
        private void CheckFence2(List<string> inputs)
        {
            for (int i = this.X-1; i >= 0; i--)
            {
                if (CheckFence(inputs[i][this.Y]))
                {
                    for (int j = this.X + 1; j < inputs.Count; j++)
                    {
                        if (CheckFence(inputs[j][this.Y])) 
                        {
                            this.IsClosed = true;
                            break;
                        }
                    }
                    break;
                }
            }
            
            if (this.IsClosed)
            {
                bool isClosed = false;
                for (int i = this.Y - 1; i >= 0; i--)
                {
                    if (CheckFence(inputs[this.X][i]))
                    {
                        for (int j = this.Y + 1; j < inputs[this.X].Length; j++)
                        {
                            if (CheckFence(inputs[this.X][j]))
                            {
                                isClosed = true;
                                break;
                            }
                        }
                        break;
                    }
                }
                this.IsClosed = isClosed;
            }
        }
        private bool CheckFence(char c)
            => c == '|' || c == '+' || c == '-';
    }
    class Map
    {
        public List<Point> Points { get; } = new List<Point>();
        public Map(List<string> inputs)
        {
            for (int i = 0; i < inputs.Count; i++)
                for (int j = 0; j < inputs[i].Length; j++)
                    if (inputs[i][j] == 'o')
                        this.Points.Add(new Point(i, j, inputs));
        }
    }
}
