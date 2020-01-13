using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Guessing_n_Cheating
{
    internal interface ICheat
    {
        int Check(List<Call> calls, Call victory);
    }
}
