﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodinGame.Medium.Locked_in_gear
{
    internal class Solution : ICodinGame
    {
        private static List<string> Inputs = new List<string>()
        {
            //A Dead End
            //"0 0 1",
            //"4 0 1",
            //"2 2 1",
            //"2 4 1",
            //"2 0 1",
            //Jamned
            //"0 0 3",
            //"0 4 1",
            //"3 4 2",
            //An entire different problem
            //"10 10 2",
            //"0 0 3",
            //"0 4 1",
            //"3 4 2",
            //"10 14 2",
            //The missing link
            //"1 1 1",
            //"1 3 1",
            //"1 7 1"
            //This problem is beyond me
            //"0 0 1",
            //"0 12 3",
            //"0 6 1",
            //"0 16 1",
            //"0 8 1",
            //"3 16 2",
            //"0 4 1",
            //"0 2 1",
            #region Too Many
            "0 0 1",
            "2 2 1",
            "0 2 1",
            "4 2 1",
            "0 4 1",
            "6 2 1",
            "0 6 1",
            "8 2 1",
            "0 8 1",
            "10 2 1",
            "0 10 1",
            "12 2 1",
            "0 12 1",
            "14 2 1",
            "0 14 1",
            "16 2 1",
            "0 16 1",
            "18 2 1",
            "0 18 1",
            "20 2 1",
            "4 4 1",
            "6 6 1",
            "4 6 1",
            "8 6 1",
            "4 8 1",
            "10 6 1",
            "4 10 1",
            "12 6 1",
            "4 12 1",
            "14 6 1",
            "4 14 1",
            "16 6 1",
            "4 16 1",
            "18 6 1",
            "4 18 1",
            "20 6 1",
            "4 20 1",
            "22 6 1",
            "4 22 1",
            "24 6 1",
            "8 8 1",
            "10 10 1",
            "8 10 1",
            "12 10 1",
            "8 12 1",
            "14 10 1",
            "8 14 1",
            "16 10 1",
            "8 16 1",
            "18 10 1",
            "8 18 1",
            "20 10 1",
            "8 20 1",
            "22 10 1",
            "8 22 1",
            "24 10 1",
            "8 24 1",
            "26 10 1",
            "8 26 1",
            "28 10 1",
            "12 12 1",
            "14 14 1",
            "12 14 1",
            "16 14 1",
            "12 16 1",
            "18 14 1",
            "12 18 1",
            "20 14 1",
            "12 20 1",
            "22 14 1",
            "12 22 1",
            "24 14 1",
            "12 24 1",
            "26 14 1",
            "12 26 1",
            "28 14 1",
            "12 28 1",
            "30 14 1",
            "12 30 1",
            "32 14 1",
            "16 16 1",
            "18 18 1",
            "16 18 1",
            "20 18 1",
            "16 20 1",
            "22 18 1",
            "16 22 1",
            "24 18 1",
            "16 24 1",
            "26 18 1",
            "16 26 1",
            "28 18 1",
            "16 28 1",
            "30 18 1",
            "16 30 1",
            "32 18 1",
            "16 32 1",
            "34 18 1",
            "16 34 1",
            "36 18 1",
            "20 20 1",
            "22 22 1",
            "20 22 1",
            "24 22 1",
            "20 24 1",
            "26 22 1",
            "20 26 1",
            "28 22 1",
            "20 28 1",
            "30 22 1",
            "20 30 1",
            "32 22 1",
            "20 32 1",
            "34 22 1",
            "20 34 1",
            "36 22 1",
            "20 36 1",
            "38 22 1",
            "20 38 1",
            "40 22 1",
            "24 24 1",
            "26 26 1",
            "24 26 1",
            "28 26 1",
            "24 28 1",
            "30 26 1",
            "24 30 1",
            "32 26 1",
            "24 32 1",
            "34 26 1",
            "24 34 1",
            "36 26 1",
            "24 36 1",
            "38 26 1",
            "24 38 1",
            "40 26 1",
            "24 40 1",
            "42 26 1",
            "24 42 1",
            "44 26 1",
            "28 28 1",
            "30 30 1",
            "28 30 1",
            "32 30 1",
            "28 32 1",
            "34 30 1",
            "28 34 1",
            "36 30 1",
            "28 36 1",
            "38 30 1",
            "28 38 1",
            "40 30 1",
            "28 40 1",
            "42 30 1",
            "28 42 1",
            "44 30 1",
            "28 44 1",
            "46 30 1",
            "28 46 1",
            "48 30 1",
            "32 32 1",
            "34 34 1",
            "32 34 1",
            "36 34 1",
            "32 36 1",
            "38 34 1",
            "32 38 1",
            "40 34 1",
            "32 40 1",
            "42 34 1",
            "32 42 1",
            "44 34 1",
            "32 44 1",
            "46 34 1",
            "32 46 1",
            "48 34 1",
            "32 48 1",
            "50 34 1",
            "32 50 1",
            "52 34 1",
            "36 36 1",
            "38 38 1",
            "36 38 1",
            "40 38 1",
            "36 40 1",
            "42 38 1",
            "36 42 1",
            "44 38 1",
            "36 44 1",
            "46 38 1",
            "36 46 1",
            "48 38 1",
            "36 48 1",
            "50 38 1",
            "36 50 1",
            "52 38 1",
            "36 52 1",
            "54 38 1",
            "36 54 1",
            "56 38 1",
            "40 40 1",
            "42 42 1",
            "40 42 1",
            "44 42 1",
            "40 44 1",
            "46 42 1",
            "40 46 1",
            "48 42 1",
            "40 48 1",
            "50 42 1",
            "40 50 1",
            "52 42 1",
            "40 52 1",
            "54 42 1",
            "40 54 1",
            "56 42 1",
            "40 56 1",
            "58 42 1",
            "40 58 1",
            "60 42 1",
            "44 44 1",
            "46 46 1",
            "44 46 1",
            "48 46 1",
            "44 48 1",
            "50 46 1",
            "44 50 1",
            "52 46 1",
            "44 52 1",
            "54 46 1",
            "44 54 1",
            "56 46 1",
            "44 56 1",
            "58 46 1",
            "44 58 1",
            "60 46 1",
            "44 60 1",
            "62 46 1",
            "44 62 1",
            "64 46 1",
            "48 48 1",
            "50 50 1",
            "48 50 1",
            "52 50 1",
            "48 52 1",
            "54 50 1",
            "48 54 1",
            "56 50 1",
            "48 56 1",
            "58 50 1",
            "48 58 1",
            "60 50 1",
            "48 60 1",
            "62 50 1",
            "48 62 1",
            "64 50 1",
            "48 64 1",
            "66 50 1",
            "48 66 1",
            "68 50 1",
            "52 52 1",
            "54 54 1",
            "52 54 1",
            "56 54 1",
            "52 56 1",
            "58 54 1",
            "52 58 1",
            "60 54 1",
            "52 60 1",
            "62 54 1",
            "52 62 1",
            "64 54 1",
            "52 64 1",
            "66 54 1",
            "52 66 1",
            "68 54 1",
            "52 68 1",
            "70 54 1",
            "52 70 1",
            "72 54 1",
            "56 56 1",
            "58 58 1",
            "56 58 1",
            "60 58 1",
            "56 60 1",
            "62 58 1",
            "56 62 1",
            "64 58 1",
            "56 64 1",
            "66 58 1",
            "56 66 1",
            "68 58 1",
            "56 68 1",
            "70 58 1",
            "56 70 1",
            "72 58 1",
            "56 72 1",
            "74 58 1",
            "56 74 1",
            "76 58 1",
            "60 60 1",
            "62 62 1",
            "60 62 1",
            "64 62 1",
            "60 64 1",
            "66 62 1",
            "60 66 1",
            "68 62 1",
            "60 68 1",
            "70 62 1",
            "60 70 1",
            "72 62 1",
            "60 72 1",
            "74 62 1",
            "60 74 1",
            "76 62 1",
            "60 76 1",
            "78 62 1",
            "60 78 1",
            "80 62 1",
            "64 64 1",
            "66 66 1",
            "64 66 1",
            "68 66 1",
            "64 68 1",
            "70 66 1",
            "64 70 1",
            "72 66 1",
            "64 72 1",
            "74 66 1",
            "64 74 1",
            "76 66 1",
            "64 76 1",
            "78 66 1",
            "64 78 1",
            "80 66 1",
            "64 80 1",
            "82 66 1",
            "64 82 1",
            "84 66 1",
            "68 68 1",
            "70 70 1",
            "68 70 1",
            "72 70 1",
            "68 72 1",
            "74 70 1",
            "68 74 1",
            "76 70 1",
            "68 76 1",
            "78 70 1",
            "68 78 1",
            "80 70 1",
            "68 80 1",
            "82 70 1",
            "68 82 1",
            "84 70 1",
            "68 84 1",
            "86 70 1",
            "68 86 1",
            "88 70 1",
            "72 72 1",
            "74 74 1",
            "72 74 1",
            "76 74 1",
            "72 76 1",
            "78 74 1",
            "72 78 1",
            "80 74 1",
            "72 80 1",
            "82 74 1",
            "72 82 1",
            "84 74 1",
            "72 84 1",
            "86 74 1",
            "72 86 1",
            "88 74 1",
            "72 88 1",
            "90 74 1",
            "72 90 1",
            "92 74 1",
            "76 76 1",
            "78 78 1",
            "76 78 1",
            "80 78 1",
            "76 80 1",
            "82 78 1",
            "76 82 1",
            "84 78 1",
            "76 84 1",
            "86 78 1",
            "76 86 1",
            "88 78 1",
            "76 88 1",
            "90 78 1",
            "76 90 1",
            "92 78 1",
            "76 92 1",
            "94 78 1",
            "76 94 1",
            "96 78 1",
            "80 80 1",
            "82 82 1",
            "80 82 1",
            "84 82 1",
            "80 84 1",
            "86 82 1",
            "80 86 1",
            "88 82 1",
            "80 88 1",
            "90 82 1",
            "80 90 1",
            "92 82 1",
            "80 92 1",
            "94 82 1",
            "80 94 1",
            "96 82 1",
            "80 96 1",
            "98 82 1",
            "80 98 1",
            "100 82 1",
            "84 84 1",
            "86 86 1",
            "84 86 1",
            "88 86 1",
            "84 88 1",
            "90 86 1",
            "84 90 1",
            "92 86 1",
            "84 92 1",
            "94 86 1",
            "84 94 1",
            "96 86 1",
            "84 96 1",
            "98 86 1",
            "84 98 1",
            "100 86 1",
            "84 100 1",
            "102 86 1",
            "84 102 1",
            "104 86 1",
            "88 88 1",
            "90 90 1",
            "88 90 1",
            "92 90 1",
            "88 92 1",
            "94 90 1",
            "88 94 1",
            "96 90 1",
            "88 96 1",
            "98 90 1",
            "88 98 1",
            "100 90 1",
            "88 100 1",
            "102 90 1",
            "88 102 1",
            "104 90 1",
            "88 104 1",
            "106 90 1",
            "88 106 1",
            "108 90 1",
            "92 92 1",
            "94 94 1",
            "92 94 1",
            "96 94 1",
            "92 96 1",
            "98 94 1",
            "92 98 1",
            "100 94 1",
            "92 100 1",
            "102 94 1",
            "92 102 1",
            "104 94 1",
            "92 104 1",
            "106 94 1",
            "92 106 1",
            "108 94 1",
            "92 108 1",
            "110 94 1",
            "92 110 1",
            "112 94 1",
            "96 96 1",
            "98 98 1",
            "96 98 1",
            "100 98 1",
            "96 100 1",
            "102 98 1",
            "96 102 1",
            "104 98 1",
            "96 104 1",
            "106 98 1",
            "96 106 1",
            "108 98 1",
            "96 108 1",
            "110 98 1",
            "96 110 1",
            "112 98 1",
            "96 112 1",
            "114 98 1",
            "96 114 1",
            "116 98 1",
            "100 100 1",
            "102 102 1",
            "100 102 1",
            "104 102 1",
            "100 104 1",
            "106 102 1",
            "100 106 1",
            "108 102 1",
            "100 108 1",
            "110 102 1",
            "100 110 1",
            "112 102 1",
            "100 112 1",
            "114 102 1",
            "100 114 1",
            "116 102 1",
            "100 116 1",
            "118 102 1",
            "100 118 1",
            "120 102 1",
            "104 104 1",
            "106 106 1",
            "104 106 1",
            "108 106 1",
            "104 108 1",
            "110 106 1",
            "104 110 1",
            "112 106 1",
            "104 112 1",
            "114 106 1",
            "104 114 1",
            "116 106 1",
            "104 116 1",
            "118 106 1",
            "104 118 1",
            "120 106 1",
            "104 120 1",
            "122 106 1",
            "104 122 1",
            "124 106 1",
            "108 108 1",
            "110 110 1",
            "108 110 1",
            "112 110 1",
            "108 112 1",
            "114 110 1",
            "108 114 1",
            "116 110 1",
            "108 116 1",
            "118 110 1",
            "108 118 1",
            "120 110 1",
            "108 120 1",
            "122 110 1",
            "108 122 1",
            "124 110 1",
            "108 124 1",
            "126 110 1",
            "108 126 1",
            "128 110 1",
            "112 112 1",
            "114 114 1",
            "112 114 1",
            "116 114 1",
            "112 116 1",
            "118 114 1",
            "112 118 1",
            "120 114 1",
            "112 120 1",
            "122 114 1",
            "112 122 1",
            "124 114 1",
            "112 124 1",
            "126 114 1",
            "112 126 1",
            "128 114 1",
            "112 128 1",
            "130 114 1",
            "112 130 1",
            "132 114 1",
            "116 116 1",
            "118 118 1",
            "116 118 1",
            "120 118 1",
            "116 120 1",
            "122 118 1",
            "116 122 1",
            "124 118 1",
            "116 124 1",
            "126 118 1",
            "116 126 1",
            "128 118 1",
            "116 128 1",
            "130 118 1",
            "116 130 1",
            "132 118 1",
            "116 132 1",
            "134 118 1",
            "116 134 1",
            "136 118 1",
            "120 120 1",
            "122 122 1",
            "120 122 1",
            "124 122 1",
            "120 124 1",
            "126 122 1",
            "120 126 1",
            "128 122 1",
            "120 128 1",
            "130 122 1",
            "120 130 1",
            "132 122 1",
            "120 132 1",
            "134 122 1",
            "120 134 1",
            "136 122 1",
            "120 136 1",
            "138 122 1",
            "120 138 1",
            "140 122 1",
            "124 124 1",
            "126 126 1",
            "124 126 1",
            "128 126 1",
            "124 128 1",
            "130 126 1",
            "124 130 1",
            "132 126 1",
            "124 132 1",
            "134 126 1",
            "124 134 1",
            "136 126 1",
            "124 136 1",
            "138 126 1",
            "124 138 1",
            "140 126 1",
            "124 140 1",
            "142 126 1",
            "124 142 1",
            "144 126 1",
            "128 128 1",
            "130 130 1",
            "128 130 1",
            "132 130 1",
            "128 132 1",
            "134 130 1",
            "128 134 1",
            "136 130 1",
            "128 136 1",
            "138 130 1",
            "128 138 1",
            "140 130 1",
            "128 140 1",
            "142 130 1",
            "128 142 1",
            "144 130 1",
            "128 144 1",
            "146 130 1",
            "128 146 1",
            "148 130 1",
            "132 132 1",
            "134 134 1",
            "132 134 1",
            "136 134 1",
            "132 136 1",
            "138 134 1",
            "132 138 1",
            "140 134 1",
            "132 140 1",
            "142 134 1",
            "132 142 1",
            "144 134 1",
            "132 144 1",
            "146 134 1",
            "132 146 1",
            "148 134 1",
            "132 148 1",
            "150 134 1",
            "132 150 1",
            "152 134 1",
            "136 136 1",
            "138 138 1",
            "136 138 1",
            "140 138 1",
            "136 140 1",
            "142 138 1",
            "136 142 1",
            "144 138 1",
            "136 144 1",
            "146 138 1",
            "136 146 1",
            "148 138 1",
            "136 148 1",
            "150 138 1",
            "136 150 1",
            "152 138 1",
            "136 152 1",
            "154 138 1",
            "136 154 1",
            "156 138 1",
            "140 140 1",
            "142 142 1",
            "140 142 1",
            "144 142 1",
            "140 144 1",
            "146 142 1",
            "140 146 1",
            "148 142 1",
            "140 148 1",
            "150 142 1",
            "140 150 1",
            "152 142 1",
            "140 152 1",
            "154 142 1",
            "140 154 1",
            "156 142 1",
            "140 156 1",
            "158 142 1",
            "140 158 1",
            "160 142 1",
            "144 144 1",
            "146 146 1",
            "144 146 1",
            "148 146 1",
            "144 148 1",
            "150 146 1",
            "144 150 1",
            "152 146 1",
            "144 152 1",
            "154 146 1",
            "144 154 1",
            "156 146 1",
            "144 156 1",
            "158 146 1",
            "144 158 1",
            "160 146 1",
            "144 160 1",
            "162 146 1",
            "144 162 1",
            "164 146 1",
            "148 148 1",
            "150 150 1",
            "148 150 1",
            "152 150 1",
            "148 152 1",
            "154 150 1",
            "148 154 1",
            "156 150 1",
            "148 156 1",
            "158 150 1",
            "148 158 1",
            "160 150 1",
            "148 160 1",
            "162 150 1",
            "148 162 1",
            "164 150 1",
            "148 164 1",
            "166 150 1",
            "148 166 1",
            "168 150 1",
            "152 152 1",
            "154 154 1",
            "152 154 1",
            "156 154 1",
            "152 156 1",
            "158 154 1",
            "152 158 1",
            "160 154 1",
            "152 160 1",
            "162 154 1",
            "152 162 1",
            "164 154 1",
            "152 164 1",
            "166 154 1",
            "152 166 1",
            "168 154 1",
            "152 168 1",
            "170 154 1",
            "152 170 1",
            "172 154 1",
            "156 156 1",
            "158 158 1",
            "156 158 1",
            "160 158 1",
            "156 160 1",
            "162 158 1",
            "156 162 1",
            "164 158 1",
            "156 164 1",
            "166 158 1",
            "156 166 1",
            "168 158 1",
            "156 168 1",
            "170 158 1",
            "156 170 1",
            "172 158 1",
            "156 172 1",
            "174 158 1",
            "156 174 1",
            "176 158 1",
            "160 160 1",
            "162 162 1",
            "160 162 1",
            "164 162 1",
            "160 164 1",
            "166 162 1",
            "160 166 1",
            "168 162 1",
            "160 168 1",
            "170 162 1",
            "160 170 1",
            "172 162 1",
            "160 172 1",
            "174 162 1",
            "160 174 1",
            "176 162 1",
            "160 176 1",
            "178 162 1",
            "160 178 1",
            "180 162 1",
            "164 164 1",
            "166 166 1",
            "164 166 1",
            "168 166 1",
            "164 168 1",
            "170 166 1",
            "164 170 1",
            "172 166 1",
            "164 172 1",
            "174 166 1",
            "164 174 1",
            "176 166 1",
            "164 176 1",
            "178 166 1",
            "164 178 1",
            "180 166 1",
            "164 180 1",
            "182 166 1",
            "164 182 1",
            "184 166 1",
            "168 168 1",
            "170 170 1",
            "168 170 1",
            "172 170 1",
            "168 172 1",
            "174 170 1",
            "168 174 1",
            "176 170 1",
            "168 176 1",
            "178 170 1",
            "168 178 1",
            "180 170 1",
            "168 180 1",
            "182 170 1",
            "168 182 1",
            "184 170 1",
            "168 184 1",
            "186 170 1",
            "168 186 1",
            "188 170 1",
            "172 172 1",
            "174 174 1",
            "172 174 1",
            "176 174 1",
            "172 176 1",
            "178 174 1",
            "172 178 1",
            "180 174 1",
            "172 180 1",
            "182 174 1",
            "172 182 1",
            "184 174 1",
            "172 184 1",
            "186 174 1",
            "172 186 1",
            "188 174 1",
            "172 188 1",
            "190 174 1",
            "172 190 1",
            "192 174 1",
            "176 176 1",
            "178 178 1",
            "176 178 1",
            "180 178 1",
            "176 180 1",
            "182 178 1",
            "176 182 1",
            "184 178 1",
            "176 184 1",
            "186 178 1",
            "176 186 1",
            "188 178 1",
            "176 188 1",
            "190 178 1",
            "176 190 1",
            "192 178 1",
            "176 192 1",
            "194 178 1",
            "176 194 1",
            "196 178 1",
            "180 180 1",
            "182 182 1",
            "180 182 1",
            "184 182 1",
            "180 184 1",
            "186 182 1",
            "180 186 1",
            "188 182 1",
            "180 188 1",
            "190 182 1",
            "180 190 1",
            "192 182 1",
            "180 192 1",
            "194 182 1",
            "180 194 1",
            "196 182 1",
            "180 196 1",
            "198 182 1",
            "180 198 1",
            "200 182 1",
            "184 184 1",
            "186 186 1",
            "184 186 1",
            "188 186 1",
            "184 188 1",
            "190 186 1",
            "184 190 1",
            "192 186 1",
            "184 192 1",
            "194 186 1",
            "184 194 1",
            "196 186 1",
            "184 196 1",
            "198 186 1",
            "184 198 1",
            "200 186 1",
            "184 200 1",
            "202 186 1",
            "184 202 1",
            "204 186 1",
            "188 188 1",
            "190 190 1",
            "188 190 1",
            "192 190 1",
            "188 192 1",
            "194 190 1",
            "188 194 1",
            "196 190 1",
            "188 196 1",
            "198 190 1",
            "188 198 1",
            "200 190 1",
            "188 200 1",
            "202 190 1",
            "188 202 1",
            "204 190 1",
            "188 204 1",
            "206 190 1",
            "188 206 1",
            "208 190 1",
            "192 192 1",
            "194 194 1",
            "192 194 1",
            "196 194 1",
            "192 196 1",
            "198 194 1",
            "192 198 1",
            "200 194 1",
            "192 200 1",
            "202 194 1",
            "192 202 1",
            "204 194 1",
            "192 204 1",
            "206 194 1",
            "192 206 1",
            "208 194 1",
            "192 208 1",
            "210 194 1",
            "192 210 1",
            "212 194 1",
            "196 196 1",
            "198 198 1",
            "196 198 1",
            "200 198 1",
            "196 200 1",
            "202 198 1",
            "196 202 1",
            "204 198 1",
            "196 204 1",
            "206 198 1",
            "196 206 1",
            "208 198 1",
            "196 208 1",
            "210 198 1",
            "196 210 1",
            "212 198 1",
            "196 212 1",
            "196 214 1",
            "216 198 1",
            "214 198 1",
#endregion
        };
        public void Run()
        {
            int N = Inputs.Count;
            List<Gear> gears = new List<Gear>();
            for (int i = 0; i < N; i++)
            {
                string[] inputs = Inputs[i].Split(' ');
                int x = int.Parse(inputs[0]);
                int y = int.Parse(inputs[1]);
                int r = int.Parse(inputs[2]);
                Gear gear = new Gear(x, y, r);
                Console.Error.WriteLine(gear);
                gears.Add(gear);
            }
            foreach (Gear gear in gears)
            {
                gear.Toucheds = gears.Where(x => x != gear && x.Touching(gear)).ToList();
                if (gear.Toucheds.Count > 0)
                    gear.Position = int.MinValue;
            }
            bool isCorrect = false;
            foreach (Gear gear in gears.Where(x => x.Toucheds.Count == 1).OrderBy(x => x.X + x.Y))
            {
                if (gear.IsClockwise == null)
                {
                    isCorrect |= gear.SetClockWise(null);
                    Console.Error.WriteLine("-------------------------");
                    foreach (Gear gear2 in gears.OrderBy(x => x.X + x.Y))
                        Console.Error.WriteLine(gear2);
                }
            }
            if (!isCorrect)
                Console.WriteLine("NOT MOVING");
            else
            {
                Gear last = gears.OrderBy(x => x.Position).LastOrDefault();
                if (!last.IsClockwise.HasValue)
                    Console.WriteLine("NOT MOVING");
                else if (last.IsClockwise.Value)
                    Console.WriteLine("CW");
                else
                    Console.WriteLine("CCW");
            }
        }
    }
}