using System;
using System.Collections.Generic;
using System.Text;

namespace CodingGame.DetectivePikaptchaEp2
{
    public class Map
    {
        private int[,] Cells;
        private int Width;
        private int Height;
        private Pikaptcha Pikaptcha;
        public Map(int width, int height)
        {
            this.Cells = new int[width, height];
            this.Width = width;
            this.Height = height;
        }

        public void SetPikaptcha(int i, int j, char face)
            => this.Pikaptcha = new Pikaptcha(i, j, face);

        public void SetWallOn(string direction)
            => this.Pikaptcha.SetWallOn(direction);

        public void Zero(int i, int j)
            => this.Cells[i, j] = int.MinValue;

        public void Play()
        {
            this.Cells[this.Pikaptcha.X, this.Pikaptcha.Y]++;
            this.Play(this.Pikaptcha.X, this.Pikaptcha.Y);
        }

        private void Play(int x, int y)
        {
            (int X, int Y) result = this.Pikaptcha.Move(x, y, this.Cells, this.Width, this.Height);
            if (result.X == this.Pikaptcha.X && result.Y == this.Pikaptcha.Y)
                this.Show();
            else
            {
                this.Cells[result.X, result.Y]++;
                this.Play(result.X, result.Y);
            }
        }

        public void Show()
        {
            for (int j = 0; j < this.Height; j++)
            {
                StringBuilder end = new StringBuilder();
                for (int i = 0; i < this.Width; i++)
                {
                    end.Append(this.Cells[i, j] < 0 ? "#" : this.Cells[i, j].ToString());
                }
                Console.WriteLine(end.ToString());
            }
        }
    }
}
