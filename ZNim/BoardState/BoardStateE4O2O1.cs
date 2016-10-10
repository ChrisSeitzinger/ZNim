using System.Collections.Generic;

namespace ZNim.Core
{
    internal class BoardStateE4O2O1 : BoardState
    {
        public BoardStateE4O2O1(List<Tuple>[] tuples) : base(tuples)
        {
        }

        public override Move GetBestMove()
        {
            if (0 == Tuple4Count(tuples))
            {
                if (1 == Tuple2Count(tuples))
                {
                    // Remove the last tuple2 to force only an odd number of tuple1s
                    Tuple tuple = GetTuples(MatchTuple2Or3)[0];
                    if (2 == tuple.Length)
                    {
                        return new Move(tuple.RowIndex, tuple.StartIndex, tuple.Length);
                    }
                    else if (3 == tuple.Length)
                    {
                        // TODO: Randomize:
                        // = Move(tuple.RowIndex, tuple.StartIndex, tuple.Length - 1)
                        // = Move(tuple.RowIndex, tuple.StartIndex + 1, tuple.Length - 1)
                        return new Move(tuple.RowIndex, tuple.StartIndex, tuple.Length - 1);
                    }
                }
                else
                {
                    // Look for a tuple3 to remove to even out the tuple2s and tuple1s
                    // Remove the last tuple2 to force only an odd number of tuple1s
                    List<Tuple> tupleList = GetTuples(MatchTuple3);
                    if (tupleList.Count > 0)
                    {
                        // TODO: Randomize:
                        // int index = random(0, tupleList.Length - 1);
                        // Tuple tuple = tupleList[index];
                        Tuple tuple = tupleList[0];
                        return new Move(tuple.RowIndex, tuple.StartIndex, tuple.Length);
                    }
                    else
                    {
                        return ChooseRandomOne();
                    }
                }
            }
            else // Tuple4Count == 2
            {
                // With an odd number of tuple2s then there must be exactly 1
                Tuple tuple = GetTuples(MatchTuple2Or3)[0];
                if (2 == tuple.Length)
                {
                    return new Move(tuple.RowIndex, tuple.StartIndex, 1);
                }
                else if (3 == tuple.Length)
                {
                    // TODO: Randomize:
                    // = Move(tuple.RowIndex, tuple.StartIndex, tuple.Length - 1)
                    // = Move(tuple.RowIndex, tuple.StartIndex + 1, 1)
                    return new Move(tuple.RowIndex, tuple.StartIndex, tuple.Length - 1);
                }
            }

            throw new System.NotImplementedException();
        }
    }
}