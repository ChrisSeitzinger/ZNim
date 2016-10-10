namespace ZNim.Core
{
    public class ZNimRowIndexOutOfRangeException : ZNimException
    {
        public ZNimRowIndexOutOfRangeException(int row)
            : base(string.Format(Constants.MoveValidationMessages.RowIndexOutOfRangeError, row)) { }
    }
}