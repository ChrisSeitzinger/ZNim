namespace ZNim.Core
{
    public class Pin
    {
        public Pin(Row row)
        {
            this.Row = row;
            this.Available = false;
        }

        public Row Row
        {
            get;
            private set;
        }

        public bool Available
        {
            get;
            internal set;
        }
    }
}
