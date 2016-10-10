namespace ZNim.Client
{
    public class RowRenderData
    {
        public RowRenderData(BoardRenderData board, int rowIndex)
        {
            this.Board = board;
            int rowCount = rowIndex + 1;
            this.Pins = new PinRenderData[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                Pins[i] = new PinRenderData(this);
            }
        }

        public BoardRenderData Board
        {
            get;
            private set;
        }

        public PinRenderData[] Pins
        {
            get;
            private set;
        }

        public int CursorTop;
    }
}
