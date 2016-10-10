using System;

namespace ZNim.Core
{
    public class Player : IPlayer
    {
        static Random random = new Random();

        public Player(string name)
        {
            this.Name = name;
            this.Id = CreatePlayerId();
        }

        public string Name
        {
            get;
            private set;
        }

        public int Id
        {
            get;
            private set;
        }

        public virtual Move GetMove(Board board)
        {
            throw new NotImplementedException("This method must be implemented by a derived class");
        }

        private int CreatePlayerId()
        {
            return random.Next(0, 99);
        }
    }
}
