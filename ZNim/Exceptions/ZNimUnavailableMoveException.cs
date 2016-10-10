namespace ZNim.Core
{
    public class ZNimUnavailableMoveException : ZNimException
    {
        public ZNimUnavailableMoveException(int firstPin, int lastPin)
            : base(string.Format(Constants.MoveValidationMessages.MoveUnavailableError, firstPin, lastPin)) { }
    }
}
