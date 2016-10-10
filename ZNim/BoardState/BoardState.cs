using System;
using System.Collections.Generic;

namespace ZNim.Core
{
    internal abstract class BoardState
    {
        protected List<Tuple>[] tuples;

        protected BoardState(List<Tuple>[] tuples)
        {
            this.tuples = tuples;
        }

        public abstract Move GetBestMove();

        protected bool MatchTuple1or3or5(int length)
        {
            return (1 == length || 3 == length || 5 == length);
        }

        protected bool MatchTuple2Or3(int length)
        {
            return (2 == length || 3 == length);
        }

        protected bool MatchTuple3(int length)
        {
            return (3 == length);
        }

        protected bool MatchTuple3or5(int length)
        {
            return (3 == length || 5 == length);
        }

        protected bool MatchTuple4(int length)
        {
            return (4 == length);
        }

        protected bool MatchAny(int length)
        {
            return true;
        }

        protected List<Tuple> GetTuples(Func<int, bool> Match)
        {
            List<Tuple> tupleMatchList = new List<Tuple>(5);

            // Remove the last tuple2 to force only an odd number of tuple1s
            foreach (List<Tuple> tupleList in tuples)
            {
                foreach (Tuple tuple in tupleList)
                {
                    if (Match(tuple.Length))
                    {
                        tupleMatchList.Add(tuple);
                    }
                }
            }

            return tupleMatchList;
        }

        protected Move ChooseRandomOne()
        {
            List<Tuple> tupleList = GetTuples(MatchAny);
            return new Move(tupleList[0].RowIndex, tupleList[0].StartIndex, 1);
        }

        public static BoardState Create(Board board)
        {
            BoardState state = null;

            List<Tuple>[] tuples = CreateTuples(board);
            int tuple4Count = Tuple4Count(tuples);
            int tuple2Count = Tuple2Count(tuples);
            int tuple1Count = Tuple1Count(tuples);

            if (IsOdd(tuple4Count))
            {
                if (IsOdd(tuple2Count))
                {
                    if (IsOdd(tuple1Count))
                    {
                        state = new BoardStateO4O2O1(tuples);
                    }
                    else
                    {
                        state = new BoardStateO4O2E1(tuples);
                    }
                }
                else // Even tuple2Count
                {
                    if (IsOdd(tuple1Count))
                    {
                        state = new BoardStateO4E2O1(tuples);
                    }
                    else // Even tuple1Count
                    {
                        state = new BoardStateO4E2E1(tuples);
                    }
                }
            }
            else // Even tuple4Count
            {
                if (IsOdd(tuple2Count))
                {
                    if (IsOdd(tuple1Count))
                    {
                        state = new BoardStateE4O2O1(tuples);
                    }
                    else
                    {
                        state = new BoardStateE4O2E1(tuples);
                    }
                }
                else // Even tuple2Count
                {
                    if (IsOdd(tuple1Count))
                    {
                        state = new BoardStateE4E2O1(tuples);
                    }
                    else // Even tuple1Count
                    {
                        state = new BoardStateE4E2E1(tuples);
                    }
                }
            }

            return state;
        }

        private static List<Tuple>[] CreateTuples(Board board)
        {
            List<Tuple>[] tuples = new List<Tuple>[board.RowCount + 1];
            for (int i = 0; i < tuples.Length; i++)
            {
                tuples[i] = new List<Tuple>();
            }

            bool[][] pins = board.GetPins();

            for (int iRow = 0; iRow < pins.Length; iRow++)
            {
                bool[] row = pins[iRow];

                int start = -1;
                int count = 0;

                // Count the pins for this row
                for (int i = 0; i < row.Length; i++)
                {
                    if (row[i])
                    {
                        if (0 == count)
                        {
                            start = i;
                        }
                        count++;
                    }
                    else
                    {
                        if (count > 0)
                        {
                            Tuple tuple = new Tuple(iRow, start, count);
                            tuples[count].Add(tuple);
                        }
                        count = 0;
                    }
                }
                if (count > 0)
                {
                    Tuple tuple = new Tuple(iRow, start, count);
                    tuples[count].Add(tuple);
                }
            }

            return tuples;
        }

        protected static int Tuple1Count(List<Tuple>[] tuples)
        {
            return tuples[1].Count + tuples[3].Count + tuples[5].Count;
        }

        protected static int Tuple2Count(List<Tuple>[] tuples)
        {
            return tuples[2].Count + tuples[3].Count;
        }

        protected static int Tuple4Count(List<Tuple>[] tuples)
        {
            return tuples[4].Count + tuples[5].Count;
        }

        private static bool IsOdd(int i)
        {
            //return (i % 2) == 1;
            return (i & 1) == 1;
        }

        private static bool IsEven(int i)
        {
            return !IsOdd(i);
        }
    }
}
