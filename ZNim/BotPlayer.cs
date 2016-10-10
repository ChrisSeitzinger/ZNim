using System;

namespace ZNim.Core
{
    public class BotPlayer : Player
    {
        private static Random random = new Random();

        public BotPlayer() : base(GetBotName())
        {
        }

        public override Move GetMove(Board board)
        {
            BoardState boardState = BoardState.Create(board);

            return boardState.GetBestMove();
        }

        private static string GetBotName()
        {
            return "BottyBot";
        }
    }
}
