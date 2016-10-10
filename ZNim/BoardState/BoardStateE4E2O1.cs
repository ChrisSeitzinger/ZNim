using System;
using System.Collections.Generic;

namespace ZNim.Core
{
    internal class BoardStateE4E2O1 : BoardState
    {
        public BoardStateE4E2O1(List<Tuple>[] tuples) : base(tuples)
        {
        }

        public override Move GetBestMove()
        {
            List<Tuple> tupleList = GetTuples(MatchTuple1or3or5);
            if (tupleList.Count > 0)
            {
                // TODO: Randomize:
                // int index = random(0, tupleList.Length - 1);
                // Tuple tuple = tupleList[index];
                Tuple tuple = tupleList[0];

                // TODO: Randomize:
                // = Move(tuple.RowIndex, tuple.StartIndex, 1);
                // = Move(tuple.RowIndex, tuple.StartIndex + tuple.Length - 1, 1);
                return new Move(tuple.RowIndex, tuple.StartIndex, 1);
            }

            throw new System.NotImplementedException();
        }
    }
}