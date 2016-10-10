using System;
using ZNim.Core;

namespace ZNim.Client
{
    public class BoardRenderer
    {
        private int cursorLeft;
        private int cursorTop;
        private Board board;
        private BoardRenderData boardRenderData;

        public BoardRenderer(Board board)
        {
            this.board = board;
            this.boardRenderData = new BoardRenderData(board.RowCount);
        }

        public void Render()
        {
            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;
            RenderBoard(cursorLeft, cursorTop);
        }

        private void RenderBoard(int left, int top)
        {
            Console.CursorLeft = left;
            Console.CursorTop = top;

            bool[][] pins = board.GetPins();

            for (int iRow = 0; iRow < pins.Length; iRow++)
            {
                bool[] row = pins[iRow];
                RenderRow(row);
                WriteLine("", Console.ForegroundColor);
            }
            WriteLine("", Console.ForegroundColor);
        }

        public void Refresh()
        {
            int originalLeft = Console.CursorLeft;
            int originalTop = Console.CursorTop;

            RenderBoard(cursorLeft, cursorTop);

            Console.CursorLeft = originalLeft;
            Console.CursorTop = originalTop;
        }

        public void SelectRow(int rowIndex)
        {
            boardRenderData.SelectedMove.Row = rowIndex;
            RenderRowUpdate(rowIndex);
        }

        public void SelectPins(int rowIndex, int firstPinIndex, int length)
        {
            boardRenderData.SelectedMove.FirstPin = firstPinIndex;
            RowRenderData rowData = boardRenderData.Rows[rowIndex];
            for (int i = firstPinIndex; i < firstPinIndex + length; i++)
            {
                PinRenderData pinData = rowData.Pins[i];
                pinData.Selected = true;
                RenderPinUpdate(pinData);
            }
        }

        public void ClearSelection()
        {
            boardRenderData.SelectedMove.Row = -1;
            boardRenderData.SelectedMove.FirstPin = -1;
            boardRenderData.SelectedMove.Length = -1;

            foreach (RowRenderData rowData in boardRenderData.Rows)
            {
                foreach (PinRenderData pinData in rowData.Pins)
                {
                    pinData.Selected = false;
                }
            }
            Refresh();
        }

        private void RenderPinUpdate(PinRenderData pinData)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;

            Console.CursorLeft = pinData.CursorLeft;
            Console.CursorTop = pinData.Row.CursorTop;
            Write("|", pinData.Color);

            Console.CursorLeft = left;
            Console.CursorTop = top;
        }

        private void RenderRowUpdate(int rowIndex)
        {
            RowRenderData rowData = boardRenderData.Rows[rowIndex];

            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            ConsoleColor color = Console.ForegroundColor;

            Console.CursorLeft = 1;
            Console.CursorTop = rowData.CursorTop;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(rowIndex + 1);

            Console.CursorLeft = left;
            Console.CursorTop = top;
            Console.ForegroundColor = color;
        }

        private void RenderRow(bool[] row)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;

            int rowIndex = row.Length - 1;

            Write(String.Format("{0,2}  ", rowIndex + 1), ConsoleColor.White);

            RowRenderData rowData = boardRenderData.Rows[rowIndex];
            rowData.CursorTop = Console.CursorTop;

            for (int iPin = 0; iPin < row.Length; iPin++)
            {
                PinRenderData pinData = rowData.Pins[iPin];

                pinData.Available = row[iPin];
                pinData.CursorLeft = Console.CursorLeft;

                RenderPin(pinData);
                Write(" ", Console.ForegroundColor);
            }

            Console.BackgroundColor = originalBackground;
        }

        private void RenderPin(PinRenderData pinData)
        {
            pinData.CursorLeft = Console.CursorLeft;
            Write("|", pinData.Color);
        }

        private void Write(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = originalColor;
        }

        private void WriteLine(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }
    }
}
