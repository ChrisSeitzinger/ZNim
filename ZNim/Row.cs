namespace ZNim.Core
{
    public class Row
    {
        public Row(Board board, int pinCount)
        {
            this.Board = board;
            this.Pins = new Pin[pinCount];
            for (int i = 0; i < pinCount; i++)
            {
                this.Pins[i] = new Pin(this);
            }
        }

        public Board Board
        {
            get;
            private set;
        }

        public Pin[] Pins
        {
            get;
            private set;
        }
    }
}
