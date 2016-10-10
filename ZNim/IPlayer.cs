namespace ZNim.Core
{
    public interface IPlayer
    {
        string Name
        {
            get;
        }

        int Id
        {
            get;
        }

        Move GetMove(Board board);
    }
}
