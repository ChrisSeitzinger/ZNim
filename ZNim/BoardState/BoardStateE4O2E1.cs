using System;
using System.Collections.Generic;

namespace ZNim.Core
{
    internal class BoardStateE4O2E1 : BoardState
    {
        public BoardStateE4O2E1(List<Tuple>[] tuples) : base(tuples)
        {}

        public override Move GetBestMove()
        {
            if (0 == Tuple4Count(tuples))
            {
                if (1 == Tuple2Count(tuples))
                {
                    List<Tuple> tupleList = GetTuples(MatchTuple2Or3);
                    if (tupleList.Count > 0)
                    {
                        // TODO: Randomize:
                        // int index = random(0, tupleList.Length - 1);
                        // Tuple tuple = tupleList[index];
                        Tuple tuple = tupleList[0];

                        if (2 == tuple.Length)
                        {
                            // TODO: Randomize:
                            // = Move(tuple.RowIndex, tuple.StartIndex, 1);
                            // = Move(tuple.RowIndex, tuple.StartIndex + 1, 1);
                            return new Move(tuple.RowIndex, tuple.StartIndex, 1);
                        }
                        else
                        {
                            return new Move(tuple.RowIndex, tuple.StartIndex, tuple.Length);
                        }
                    }
                }
                else
                {
                    List<Tuple> tupleList = GetTuples(MatchTuple2Or3);
                    if (tupleList.Count > 0)
                    {
                        // TODO: Randomize:
                        // int index = random(0, tupleList.Length - 1);
                        // Tuple tuple = tupleList[index];
                        Tuple tuple = tupleList[0];

                        if (2 == tuple.Length)
                        {
                            return new Move(tuple.RowIndex, tuple.StartIndex, tuple.Length);
                        }
                        else
                        {
                            // TODO: Randomize
                            // = Move(tuple.RowIndex, tuple.StartIndex, 2);
                            // = Move(tuple.RowIndex, tuple.StartIndex + 1, 2);
                            return new Move(tuple.RowIndex, tuple.StartIndex, 2);
                        }
                    }
                }
            }
            else // Tuple4Count == 2
            {
                List<Tuple> tupleList = GetTuples(MatchTuple2Or3);
                if (tupleList.Count > 0)
                {
                    // TODO: Randomize:
                    // int index = random(0, tupleList.Length - 1);
                    // Tuple tuple = tupleList[index];
                    Tuple tuple = tupleList[0];

                    if (2 == tuple.Length)
                    {
                        return new Move(tuple.RowIndex, tuple.StartIndex, tuple.Length);
                    }
                    else
                    {
                        // TODO: Randomize
                        // = Move(tuple.RowIndex, tuple.StartIndex, 2);
                        // = Move(tuple.RowIndex, tuple.StartIndex + 1, 2);
                        return new Move(tuple.RowIndex, tuple.StartIndex, 2);
                    }
                }
            }

            throw new System.NotImplementedException();
        }
    }
}