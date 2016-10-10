namespace ZNim.Core
{
    public class Board
    {
        private bool[][] pins;

        public Board()
        {
            RowCount = 5;
            pins = CreateRows();

            for (int rowIndex = 0; rowIndex < pins.Length; rowIndex++)
            {
                bool[] row = pins[rowIndex];
                for (int pinIndex = 0; pinIndex < row.Length; pinIndex++)
                {
                    row[pinIndex] = true;
                }
            }
        }

        public int RowCount
        {
            get;
            private set;
        }

        public void ApplyMove(Move move)
        {
            ValidateMove(move);

            bool[] row = pins[move.Row];
            for (int i = move.FirstPin; i < move.FirstPin + move.Length; i++)
            {
                row[i] = false;
            }
        }

        // Grossly inefficient but for now return a copy of the pins so
        // the offical board cannot be manipulated by clients.
        public bool[][] GetPins()
        {
            bool[][] newPins = CreateRows();

            for (int rowIndex = 0; rowIndex < pins.Length; rowIndex++)
            {
                bool[] row = pins[rowIndex];
                bool[] newRow = newPins[rowIndex];
                for (int pinIndex = 0; pinIndex < row.Length; pinIndex++)
                {
                    newRow[pinIndex] = row[pinIndex];
                }
            }
            return newPins;
        }

        //public MoveStatus CheckMoveStatus(Move move)
        //{
        //    MoveStatus status = MoveStatus.Unmarked;
        //    int countMarked = 0;
        //    int countUnmarked = 0;

        //    ValidateMoveBounds(move);

        //    bool[] row = pins[move.Row];
        //    for (int i = move.FirstPin; i < move.FirstPin + move.Length; i++)
        //    {
        //        if (row[i])
        //        {
        //            countUnmarked++;
        //        }
        //        else
        //        {
        //            countMarked++;
        //        }
        //    }

        //    if (countMarked > 0 && countUnmarked > 0)
        //    {
        //        status = MoveStatus.PartiallyMarked;
        //    }
        //    else if (countMarked > 0 && countUnmarked == 0)
        //    {
        //        status = MoveStatus.AllMarked;
        //    }

        //    return status;
        //}

        public int AvailablePinCount()
        {
            int pinCount = 0;
            for (int rowIndex = 0; rowIndex < pins.Length; rowIndex++)
            {
                bool[] row = pins[rowIndex];
                for (int pinIndex = 0; pinIndex < row.Length; pinIndex++)
                {
                    if (row[pinIndex])
                    {
                        pinCount++;
                    }
                }
            }
            return pinCount;
        }

        private bool[][] CreateRows()
        {
            bool[][] rows = new bool[RowCount][];
            for (int i = 0; i < RowCount; i++)
            {
                rows[i] = new bool[i+1];
            }
            return rows;
        }

        private void ValidateMoveBounds(Move move)
        {
            if (move.Row < 0 || move.Row > pins.Length - 1)
                throw new ZNimRowIndexOutOfRangeException(move.Row);

            bool[] row = pins[move.Row];

            if (move.FirstPin < 0 || move.FirstPin > row.Length - 1)
                throw new ZNimFirstPinOutOfRangeException(move.FirstPin, row.Length - 1);

            if (move.Length < 0 || move.FirstPin + move.Length < 0 || move.FirstPin > row.Length - 1)
                throw new ZNimMoveExtendsBeyondRowOutOfRangeException(move.FirstPin, move.LastPin);
        }

        public bool ValidateMove(Move move)
        {
            ValidateMoveBounds(move);

            bool[] row = pins[move.Row];
            for (int i = move.FirstPin; i < move.FirstPin + move.Length; i++)
            {
                if (!row[i])
                {
                    throw new ZNimUnavailableMoveException(move.FirstPin, move.LastPin);
                }
            }
            return true;
        }

        private bool IsMoveWithinBounds(Move move)
        {
            if (move.Row < 0 || move.Row > pins.Length - 1)
                return false;

            bool[] row = pins[move.Row];

            if (move.FirstPin < 0 || move.FirstPin > row.Length - 1)
                return false;

            if (move.Length < 0 || move.FirstPin + move.Length < 0 || move.FirstPin > row.Length - 1)
                return false;

            return true;
        }

        public bool IsValidMove(Move move)
        {
            if (!IsMoveWithinBounds(move))
                return false;

            bool[] row = pins[move.Row];
            for (int i = move.FirstPin; i < move.FirstPin + move.Length; i++)
            {
                if (!row[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsValidRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= pins.Length)
                return false;

            bool[] row = pins[rowIndex];
            foreach(bool pinAvailable in row)
            {
                if (pinAvailable)
                    return true;
            }

            return false;
        }

        public bool IsValidStartPin(int rowIndex, int startPin)
        {
            if (!IsValidRow(rowIndex))
                return false;

            bool[] row = pins[rowIndex];

            if (startPin < 0 || startPin > row.Length - 1)
                return false;

            return row[startPin];
        }

        public bool IsValidPinCount(int rowIndex, int firstPinIndex, int pinCount)
        {
            if (!IsValidRow(rowIndex))
                return false;

            if (!IsValidStartPin(rowIndex, firstPinIndex))
                return false;

            bool[] row = pins[rowIndex];

            if (firstPinIndex + pinCount > row.Length)
                return false;

            return true;
        }
    }
}
