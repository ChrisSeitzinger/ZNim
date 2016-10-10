using System;

namespace ZNim.Client
{
    public class PinRenderData
    {
        const ConsoleColor MarkedColor = ConsoleColor.DarkGray;
        const ConsoleColor UnmarkedColor = ConsoleColor.Cyan;
        const ConsoleColor SelectedColor = ConsoleColor.Magenta;

        public PinRenderData(RowRenderData row)
        {
            this.Row = row;
            this.Available = true;
            this.Selected = false;
        }

        public RowRenderData Row
        {
            get;
            private set;
        }

        public int CursorLeft;
        public bool Available;
        public bool Selected;

        public ConsoleColor Color
        {
            get
            {
                if (Selected)
                {
                    return SelectedColor;
                }
                else if (Available)
                {
                    return UnmarkedColor;
                }
                else
                {
                    return MarkedColor;
                }
            }
        }
    }
}
