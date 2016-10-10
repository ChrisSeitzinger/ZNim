namespace ZNim.Core
{
    public class Constants
    {
        public class MoveValidationMessages
        {
            public const string RowIndexOutOfRangeError = "The row index {0} is not valid. Choose a row index from 0 to 4.";
            public const string FirstPinOutOfRangeError = "The pin position {0} is invalid. Choose a row index from 0 to {1}.";
            public const string MoveExtendsBeyondRowError = "The pin range {0} to {1} extends beyond the end of the row.";
            public const string MoveUnavailableError = "The move {0} to {1} includes pins which are already marked.";
        }
    }
}
