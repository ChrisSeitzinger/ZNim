namespace ZNim.Core
{
    public class RecordedMove
    {
        public RecordedMove(IPlayer player, Move move)
        {
            this.Player = player;
            this.Move = move;
        }

        public IPlayer Player
        {
            get;
            private set;
        }

        public Move Move
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return $"[{Player.Name,25}]\t{Move}";
        }
    }
}
