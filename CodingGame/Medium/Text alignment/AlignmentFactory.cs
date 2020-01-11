using System;
using System.Collections.Generic;
using System.Text;

namespace CodinGame.Medium.Text_alignment
{
    class AlignmentFactory
    {
        public IAlignment Create(string alignment)
        {
            switch (alignment)
            {
                case "LEFT":
                    return new LeftAlignment();
                case "RIGHT":
                    return new RightAlignment();
                case "CENTER":
                    return new CenterAlignment();
                case "JUSTIFY":
                    return new JustifyAlignment();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
