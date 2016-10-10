namespace ZNim.Core
{
    public class ZNimFirstPinOutOfRangeException : ZNimException
    {
        public ZNimFirstPinOutOfRangeException(int firstPin, int maxValidPin) 
            : base(string.Format(Constants.MoveValidationMessages.FirstPinOutOfRangeError, firstPin, maxValidPin)) { }
    }
}