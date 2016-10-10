using System;

namespace ZNim.Core
{
    public class ZNimMoveExtendsBeyondRowOutOfRangeException : ZNimException
    {
        public ZNimMoveExtendsBeyondRowOutOfRangeException(int firstPin, int lastPin) 
            : base(String.Format(Constants.MoveValidationMessages.MoveExtendsBeyondRowError, firstPin, lastPin)) { }
    }
}
