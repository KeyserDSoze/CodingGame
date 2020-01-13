using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Guessing_n_Cheating
{
    class Victory : ICheat
    {
        public int Check(List<Call> calls, Call victory)
        {
            foreach (Call call in calls)
                if (victory.Value < call.Value && call.CallType == CallType.TooLow)
                    return victory.Id;
                else if (victory.Value > call.Value && call.CallType == CallType.TooHigh)
                    return victory.Id;
            return 0;
        }
    }
}
