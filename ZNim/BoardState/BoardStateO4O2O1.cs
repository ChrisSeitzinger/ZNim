using System.Collections.Generic;

namespace ZNim.Core
{
    internal class BoardStateO4O2O1 : BoardState
    {
        internal BoardStateO4O2O1(List<Tuple>[] tuples) : base(tuples)
        {}

        public override Move GetBestMove()
        {
            Move move = null;

            // Need to even out the tuple2s and tuple1s by reducing the remaining tuple4 to a
            // tuple2 + a tuple1.
            if (tuples[5].Count > 0)
            {
                // TODO: Randomize:
                // = Move(4, 0, 3)
                // = Move(4, 2, 3)
                // = Move(4, 1, 1)
                // = Move(4, 3, 1)
                move = new Move(4, 0, 3);
            }
            else
            {
                List<Tuple> tupleList = GetTuples(MatchTuple4);
                if (tupleList.Count > 0)
                {
                    Tuple tuple = tupleList[0];

                    // TODO: Randomize:
                    // = Move(tuple.RowIndex, tuple.StartIndex, 1)
                    // = Move(tuple.RowIndex, tuple.StartIndex + 1, 1)
                    // = Move(tuple.RowIndex, tuple.StartIndex + 2, 1)
                    // = Move(tuple.RowIndex, tuple.StartIndex + 3, 1)
                    move = new Move(tuple.RowIndex, tuple.StartIndex, 1);
                }
            }

            return move;
        }
    }
}
