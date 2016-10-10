namespace ZNim.Core
{
    public class Tuple
    {
        public Tuple(int rowIndex, int startIndex, int length)
        {
            this.RowIndex = rowIndex;
            this.StartIndex = startIndex;
            this.Length = length;
        }

        public int RowIndex
        {
            get;
            private set;
        }

        public int StartIndex
        {
            get;
            private set;
        }

        public int Length
        {
            get;
            private set;
        }
    }
}
