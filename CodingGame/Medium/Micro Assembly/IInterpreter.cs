﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Micro_Assembly
{
    internal interface IInterpreter
    {
        int Solve(Dictionary<string, int> values);
    }
}
