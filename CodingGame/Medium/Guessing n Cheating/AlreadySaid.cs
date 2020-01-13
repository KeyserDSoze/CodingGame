using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Guessing_n_Cheating
{
    class AlreadySaid : ICheat
    {
        public int Check(List<Call> calls, Call victory)
        {
            foreach (Call call in calls)
                if (call.Value == victory.Value)
                    return call.Id;
            return 0;
        }
    }
}
