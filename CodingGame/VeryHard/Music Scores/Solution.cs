﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.VeryHard.Music_Scores
{
    class Solution : ICodinGame
    {
        List<string> Inputs = new List<string>
        {
            "420 78",
            "W 4742 B 6 W 167 B 6 W 240 B 8 W 165 B 8 W 238 B 10 W 163 B 10 W 237 B 10 W 163 B 10 W 220 B 4 W 13 B 10 W 146 B 4 W 13 B 10 W 218 B 8 W 11 B 10 W 144 B 8 W 11 B 10 W 218 B 8 W 11 B 10 W 144 B 8 W 11 B 10 W 217 B 10 W 10 B 9 W 144 B 10 W 10 B 9 W 128 B 400 W 92 B 6 W 12 B 10 W 10 B 1 W 134 B 6 W 12 B 10 W 10 B 1 W 207 B 1 W 6 B 1 W 11 B 10 W 10 B 1 W 133 B 1 W 6 B 1 W 11 B 10 W 10 B 1 W 206 B 2 W 6 B 2 W 10 B 9 W 11 B 1 W 132 B 2 W 6 B 2 W 10 B 9 W 11 B 1 W 206 B 1 W 8 B 1 W 10 B 9 W 11 B 1 W 81 B 1 W 50 B 1 W 8 B 1 W 10 B 9 W 11 B 1 W 61 B 1 W 127 B 4 W 13 B 1 W 8 B 1 W 10 B 1 W 2 B 4 W 13 B 1 W 44 B 4 W 33 B 1 W 33 B 4 W 13 B 1 W 8 B 1 W 10 B 1 W 2 B 4 W 13 B 1 W 44 B 4 W 13 B 1 W 125 B 2 W 4 B 2 W 11 B 1 W 8 B 1 W 10 B 1 W 19 B 1 W 42 B 2 W 4 B 2 W 31 B 1 W 31 B 2 W 4 B 2 W 11 B 1 W 8 B 1 W 10 B 1 W 19 B 1 W 42 B 2 W 4 B 2 W 11 B 1 W 125 B 1 W 6 B 1 W 11 B 2 W 6 B 2 W 10 B 1 W 19 B 1 W 42 B 1 W 6 B 1 W 31 B 1 W 31 B 1 W 6 B 1 W 11 B 2 W 6 B 2 W 10 B 1 W 19 B 1 W 42 B 1 W 6 B 1 W 11 B 1 W 124 B 1 W 8 B 1 W 10 B 2 W 6 B 1 W 11 B 1 W 19 B 1 W 41 B 1 W 8 B 1 W 30 B 1 W 30 B 1 W 8 B 1 W 10 B 2 W 6 B 1 W 11 B 1 W 19 B 1 W 41 B 1 W 8 B 1 W 10 B 1 W 74 B 51 W 8 B 94 W 8 B 63 W 8 B 94 W 8 B 66 W 52 B 6 W 12 B 1 W 8 B 1 W 10 B 1 W 19 B 1 W 19 B 1 W 41 B 1 W 8 B 1 W 30 B 1 W 12 B 6 W 12 B 1 W 8 B 1 W 10 B 1 W 19 B 1 W 19 B 1 W 41 B 1 W 8 B 1 W 10 B 1 W 105 B 1 W 6 B 1 W 11 B 1 W 8 B 1 W 10 B 1 W 19 B 1 W 61 B 1 W 8 B 1 W 30 B 1 W 11 B 1 W 6 B 1 W 11 B 1 W 8 B 1 W 10 B 1 W 19 B 1 W 61 B 1 W 8 B 1 W 10 B 1 W 104 B 2 W 6 B 2 W 10 B 2 W 6 B 1 W 11 B 1 W 19 B 1 W 61 B 2 W 6 B 1 W 31 B 1 W 10 B 2 W 6 B 2 W 10 B 2 W 6 B 1 W 11 B 1 W 19 B 1 W 61 B 2 W 6 B 1 W 11 B 1 W 104 B 1 W 8 B 1 W 10 B 3 W 4 B 2 W 11 B 1 W 19 B 1 W 48 B 1 W 12 B 3 W 4 B 2 W 31 B 1 W 10 B 1 W 8 B 1 W 10 B 3 W 4 B 2 W 11 B 1 W 19 B 1 W 48 B 1 W 12 B 3 W 4 B 2 W 11 B 1 W 87 B 4 W 13 B 1 W 8 B 1 W 10 B 1 W 2 B 4 W 13 B 1 W 19 B 1 W 48 B 1 W 4 B 4 W 4 B 1 W 2 B 4 W 7 B 4 W 16 B 4 W 2 B 1 W 10 B 1 W 8 B 1 W 10 B 1 W 2 B 4 W 13 B 1 W 19 B 1 W 48 B 1 W 4 B 4 W 4 B 1 W 2 B 4 W 7 B 4 W 2 B 1 W 85 B 8 W 11 B 1 W 8 B 1 W 10 B 1 W 19 B 1 W 19 B 1 W 48 B 1 W 2 B 8 W 2 B 1 W 11 B 8 W 12 B 9 W 10 B 1 W 8 B 1 W 10 B 1 W 19 B 1 W 19 B 1 W 48 B 1 W 2 B 8 W 2 B 1 W 11 B 9 W 85 B 8 W 11 B 2 W 6 B 2 W 10 B 1 W 19 B 1 W 68 B 1 W 2 B 8 W 2 B 1 W 11 B 8 W 12 B 9 W 10 B 2 W 6 B 2 W 10 B 1 W 19 B 1 W 68 B 1 W 2 B 8 W 2 B 1 W 11 B 9 W 84 B 10 W 10 B 2 W 6 B 1 W 11 B 1 W 19 B 1 W 68 B 1 W 1 B 10 W 1 B 1 W 10 B 10 W 10 B 10 W 10 B 2 W 6 B 1 W 11 B 1 W 19 B 1 W 68 B 1 W 1 B 10 W 1 B 1 W 10 B 10 W 74 B 400 W 30 B 10 W 10 B 1 W 19 B 1 W 19 B 1 W 68 B 1 W 1 B 10 W 1 B 1 W 10 B 10 W 10 B 10 W 10 B 1 W 19 B 1 W 19 B 1 W 68 B 1 W 1 B 10 W 1 B 1 W 10 B 10 W 84 B 10 W 10 B 1 W 19 B 1 W 88 B 1 W 1 B 10 W 1 B 1 W 10 B 10 W 10 B 10 W 10 B 1 W 19 B 1 W 88 B 1 W 1 B 10 W 1 B 1 W 10 B 10 W 84 B 9 W 11 B 1 W 19 B 1 W 88 B 1 W 1 B 9 W 2 B 1 W 10 B 9 W 12 B 8 W 11 B 1 W 19 B 1 W 88 B 1 W 1 B 9 W 2 B 1 W 11 B 8 W 85 B 9 W 11 B 1 W 19 B 1 W 88 B 1 W 1 B 9 W 2 B 1 W 10 B 9 W 12 B 8 W 11 B 1 W 19 B 1 W 88 B 1 W 1 B 9 W 2 B 1 W 11 B 8 W 85 B 1 W 2 B 4 W 13 B 1 W 19 B 1 W 82 B 4 W 2 B 1 W 1 B 1 W 2 B 4 W 4 B 1 W 10 B 1 W 2 B 4 W 16 B 4 W 13 B 1 W 19 B 1 W 82 B 4 W 2 B 1 W 1 B 1 W 2 B 4 W 4 B 1 W 13 B 4 W 87 B 1 W 19 B 1 W 19 B 1 W 80 B 9 W 1 B 1 W 10 B 1 W 10 B 1 W 39 B 1 W 19 B 1 W 80 B 9 W 1 B 1 W 10 B 1 W 104 B 1 W 19 B 1 W 100 B 9 W 1 B 1 W 21 B 1 W 39 B 1 W 100 B 9 W 1 B 1 W 115 B 1 W 19 B 1 W 99 B 10 W 1 B 1 W 21 B 1 W 39 B 1 W 99 B 10 W 1 B 1 W 105 B 400 W 30 B 1 W 19 B 1 W 99 B 10 W 1 B 1 W 21 B 1 W 39 B 1 W 99 B 10 W 1 B 1 W 115 B 1 W 119 B 10 W 1 B 1 W 21 B 1 W 139 B 10 W 1 B 1 W 115 B 1 W 120 B 8 W 2 B 1 W 21 B 1 W 140 B 8 W 2 B 1 W 115 B 1 W 120 B 8 W 2 B 1 W 21 B 1 W 140 B 8 W 2 B 1 W 115 B 1 W 122 B 4 W 4 B 1 W 21 B 1 W 142 B 4 W 4 B 1 W 115 B 1 W 130 B 1 W 21 B 1 W 150 B 1 W 945 B 400 W 9250",
        };
        public void Run()
        {
            string[] inputs = Inputs[0].Split(' ');
            int width = int.Parse(inputs[0]);
            int height = int.Parse(inputs[1]);
            string baseImage = Inputs[1];
            Image image = new Image(width, height, baseImage);
            image.PrintOneQuarter();
            Console.WriteLine(string.Join(",", image.GetIntervals()));
            Console.WriteLine(string.Join(",", image.GetNotePositions()));
            Console.WriteLine($"number of notes: {image.GetNotePositions().Count()}");
            Console.WriteLine(string.Join(",", image.Translate()));
            //image.Save();
        }
    }
}
