using System.Collections.Generic;

namespace ZNim.Core
{
    internal class BoardStateO4O2E1 : BoardState
    {
        public BoardStateO4O2E1(List<Tuple>[] tuples) : base(tuples)
        {}

        public override Move GetBestMove()
        {
            Move move = null;

            // Need to even out the tuple2s by reducing the remaining tuple4 to a tuple2.
            if (tuples[5].Count > 0)
            {
                // TODO: Randomize:
                // = Move(4, 0, 2)
                // = Move(4, 1, 2)
                // = Move(4, 2, 2)
                // = Move(4, 3, 2)
                move = new Move(4, 0, 2);
            }
            else
            {
                // TODO: Randomize:
                // = Move(3, 0, 2)
                // = Move(3, 2, 2)
                move = new Move(3, 0, 2);
            }

            return move;
        }
    }
}