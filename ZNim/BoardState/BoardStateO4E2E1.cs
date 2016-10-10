using System;
using System.Collections.Generic;

namespace ZNim.Core
{
    internal class BoardStateO4E2E1 : BoardState
    {
        public BoardStateO4E2E1(List<Tuple>[] tuples) : base(tuples)
        {
        }

        public override Move GetBestMove()
        {
            Move move = null;

            // Only need to even out the tuple4s.
            if (tuples[5].Count > 0)
            {
                // TODO: Randomize:
                // = Move(4, 0, 4)
                // = Move(4, 1, 4)
                move = new Move(4, 0, 4);
            }
            else
            {
                // TODO: Randomize:
                // = Move(3, 0, 4)
                // = Move(3, 1, 2)
                move = new Move(3, 0, 4);
            }

            return move;
        }
    }
}