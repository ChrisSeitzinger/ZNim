using System;
using System.Collections.Generic;

namespace ZNim.Core
{
    internal class BoardStateO4E2O1 : BoardState
    {
        public BoardStateO4E2O1(List<Tuple>[] tuples) : base(tuples)
        {
        }

        public override Move GetBestMove()
        {
            Move move = null;

            // Need to even out the tuple1s by reducing the remaining tuple4 to a tuple1.
            if (tuples[5].Count > 0)
            {
                // TODO: Randomize:
                // = Move(4, 0, 5)
                // = Move(4, 1, 3)
                move = new Move(4, 0, 5);
            }
            else
            {
                // TODO: Randomize:
                // = Move(3, 0, 3)
                // = Move(3, 1, 3)
                move = new Move(3, 0, 3);
            }

            return move;
        }
    }
}