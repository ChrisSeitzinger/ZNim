using System;
using System.Collections.Generic;

namespace ZNim.Core
{
    public class Game
    {
        private const int MaxPlayerCount = 2;

        private List<IPlayer> players;
        private int currentPlayerIndex = 0;
        private LinkedList<RecordedMove> moveHistory;

        public Game()
        {
            this.players = new List<IPlayer>(2);
            this.Board = new Board();
            this.moveHistory = new LinkedList<RecordedMove>();
        }

        public IPlayer Join(IPlayer player)
        {
            if (players.Count >= MaxPlayerCount)
            {
                throw new InvalidOperationException($"ZNim: A game may not have more than {MaxPlayerCount} players.");
            }

            players.Add(player);

            return player;
        }

        public Board Board
        {
            get;
            private set;
        }

        public void ApplyMove(Move move)
        {
            try
            {
                ValidatePlayers();

                moveHistory.AddLast(new RecordedMove(CurrentPlayer(), move));
                Board.ApplyMove(move);

                if (1 == Board.AvailablePinCount())
                {
                    Winner = CurrentPlayer();
                }
                if (0 == Board.AvailablePinCount())
                {
                    Winner = players[NextPlayerIndex()];
                }

                currentPlayerIndex = NextPlayerIndex();
            }
            catch(Exception ex)
            {
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Move History:");
                foreach (RecordedMove recMove in moveHistory)
                {
                    Console.WriteLine(recMove.ToString());
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Exception:");
                Console.WriteLine(ex.ToString());

                Console.ForegroundColor = originalColor;
                Console.ReadLine();
            }
        }

        public IPlayer CurrentPlayer()
        {
            return players[currentPlayerIndex];
        }

        public IPlayer Winner
        {
            get;
            private set;
        }

        private int NextPlayerIndex()
        {
            return (0 == currentPlayerIndex) ? 1 : 0;
        }

        private void ValidatePlayers()
        {
            if (players.Count != 2)
                throw new InvalidOperationException("There must be exactly two players.");
        }
    }
}
