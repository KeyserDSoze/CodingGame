using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Seam_Carving
{
    internal class Solution : ICodinGame
    {
        static int W = 30;
        static int H = 8;
        static int V = 29;
        static List<string> Inputs = new List<string>()
        {
            "164 174 175 173 176 171 171 169 165 162 164 166 165 162 168 169 163 174 207 173 187 196 183 177 178 164 158 162 168 185",
            "179 130 118 108 117 136 148 165 165 162 155 156 157 155 156 162 170 161 134 100 109 111 117 132 140 154 151 139 125 136",
            "93 74 102 87 73 98 98 92 96 137 146 138 136 134 132 131 133 128 91 110 112 104 78 77 86 103 122 147 150 146",
            "129 140 152 125 59 62 82 76 54 107 156 145 139 141 145 142 138 138 141 144 146 149 90 64 84 93 70 92 177 174",
            "167 159 160 133 101 83 86 59 29 67 167 171 169 155 147 142 136 129 129 126 141 113 90 74 54 71 46 51 163 189",
            "192 198 157 160 170 134 195 114 156 109 114 197 200 199 193 183 179 168 156 163 127 126 161 122 103 131 75 88 96 183",
            "190 198 153 170 173 138 129 150 191 197 118 167 202 202 204 194 187 185 184 142 132 172 171 150 125 161 135 190 145 132",
            "188 188 175 173 154 142 141 170 161 154 116 134 154 160 176 192 188 184 185 159 161 158 162 128 118 121 147 159 171 111"
        };
        public void Run()
        {
            Pixel[,] map = new Pixel[H, W];
            for (int i = 0; i < H; i++)
            {
                string[] inputs = Inputs[i].Split(' ');
                for (int j = 0; j < W; j++)
                {
                    int I = int.Parse(inputs[j]);
                    map[i, j] = new Pixel(I, i, j);
                }
            }
            int turn = W - V;
            for (int i = 0; i < turn; i++)
                map = GetNewMap(H, W - i, map);
        }
        private static Pixel[,] GetNewMap(int height, int width, Pixel[,] map)
        {
            List<Pixel>[,] memoization = new List<Pixel>[height, width];
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    bool leftRight = j > 0 && j < width - 1;
                    int leftValue = leftRight ? map[i, j - 1].Value : 0;
                    int rightValue = leftRight ? map[i, j + 1].Value : 0;
                    bool topBottom = i > 0 && i < height - 1;
                    int topValue = topBottom ? map[i - 1, j].Value : 0;
                    int bottomValue = topBottom ? map[i + 1, j].Value : 0;
                    map[i, j].Energy = Math.Abs(leftValue - rightValue) + Math.Abs(topValue - bottomValue);
                }
            }
            int min = int.MaxValue;
            List<Pixel> minPath = new List<Pixel>();
            for (int j = 0; j < width; j++)
            {
                List<Pixel> path = MinEnergy(0, j, width, height, map, memoization);
                int value = path.Sum(x => x.Energy);
                if (value < min)
                {
                    min = value;
                    minPath = path;
                }
            }
            Pixel[,] newMap = new Pixel[height, width - 1];
            for (int i = 0; i < height; i++)
            {
                int tj = 0;
                for (int j = 0; j < width; j++)
                {
                    if (!minPath.Any(x => x.X == i && x.Y == j))
                    {
                        newMap[i, tj] = new Pixel(map[i, j].Value, i, tj);
                        tj++;
                    }
                }
            }
            Console.WriteLine(min);
            return newMap;
        }
        private static List<Pixel> MinEnergy(int i, int j, int width, int height, Pixel[,] map, List<Pixel>[,] memoization)
        {
            if (memoization[i, j] != null)
                return memoization[i, j];
            List<Pixel> pixels = new List<Pixel>() { map[i, j] };
            int nextI = i + 1;
            if (nextI < height)
            {
                List<Pixel> minPaths = new List<Pixel>();
                int minValue = int.MaxValue;
                for (int k = -1; k < 2; k++)
                {
                    int key = j + k;
                    if (key >= 0 && key < width)
                    {
                        List<Pixel> path = MinEnergy(nextI, key, width, height, map, memoization);
                        int value = path.Sum(x => x.Energy);
                        if (value < minValue)
                        {
                            minValue = value;
                            minPaths = path;
                        }
                    }
                }
                pixels.AddRange(minPaths);
            }
            return memoization[i, j] = pixels;
        }
    }
}
