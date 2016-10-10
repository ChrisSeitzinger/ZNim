using ZNim.Core;

namespace ZNim.Client
{
    public class BoardRenderData
    {
        public BoardRenderData(int rowCount)
        {
            Rows = new RowRenderData[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                Rows[i] = new RowRenderData(this, i);
            }

            SelectedMove = new Move();
        }

        public RowRenderData[] Rows;
        public Move SelectedMove;
    }
}
