using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Guessing_n_Cheating
{
    class Distance : ICheat
    {
        public int Check(List<Call> calls, Call victory)
        {
            int min = int.MaxValue;
            foreach (Call call in calls)
                foreach (Call call2 in calls)
                    if (call != call2 && Math.Abs(call.Value - call2.Value) <= 1 && call.CallType != call2.CallType)
                    {
                        int max = Math.Max(call.Id, call2.Id);
                        if (max < min)
                            min = max;
                    }
            return min == int.MaxValue ? 0 : min;
        }
    }
}
