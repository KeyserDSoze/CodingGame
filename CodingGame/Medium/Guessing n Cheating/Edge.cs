using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Guessing_n_Cheating
{
    class Edge : ICheat
    {
        public int Check(List<Call> calls, Call victory)
        {
            foreach (Call call in calls)
                if (call.Value == 100 && call.CallType == CallType.TooLow)
                    return call.Id;
                else if (call.Value == 1 && call.CallType == CallType.TooHigh)
                    return call.Id;
            return 0;
        }
    }
}
