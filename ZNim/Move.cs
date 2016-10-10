namespace ZNim.Core
{
    public class Move
    {
        public Move()
        {
            this.Row = -1;
            this.FirstPin = -1;
            this.Length = -1;
        }

        public Move(int row, int firstPin, int length)
        {
            this.Row = row;
            this.FirstPin = firstPin;
            this.Length = length;
        }

        public int Row
        {
            get;
            set;
        }

        public int FirstPin
        {
            get;
            set;
        }

        public int LastPin
        {
            get
            {
                return this.FirstPin + this.Length - 1;
            }
        }

        public int Length
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"( {Row+1}, {FirstPin+1}, {Length} )";
        }
    }
}