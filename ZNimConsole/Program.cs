using System;
using ZNim.Client;
using ZNim.Core;

namespace ZNim.CommandLine
{
    class Program
    {
        static private BoardRenderer boardRenderer;

        static void Main(string[] args)
        {
            WriteIntro();

            //Game game = new Game();
            //boardRenderer = new BoardRenderer(game.Board);

            //string name = GetPlayerName("player one");
            //IPlayer player1 = new HumanPlayer(name, boardRenderer);
            //game.Join(player1);

            ////name = GetPlayerName("player two");
            //IPlayer player2 = new BotPlayer();
            //game.Join(player2);

            Game game;
            IPlayer player1;
            IPlayer player2;

            do
            {
                game = new Game();
                boardRenderer = new BoardRenderer(game.Board);

                string name = GetPlayerName("player one");
                player1 = new HumanPlayer(name, boardRenderer);
                game.Join(player1);

                //name = GetPlayerName("player two");
                player2 = new BotPlayer();
                game.Join(player2);

                Console.WriteLine();
            } while (Play(game, player1, player2));

            Console.WriteLine();
            WriteLine("Thanks for playing ZNim. Play again soon! [press Enter to exit]", Console.ForegroundColor);
            Console.ReadLine();
        }

        static private bool Play(Game game, IPlayer player1, IPlayer player2)
        {
            Move move;
            IPlayer currentPlayer = player1;

            while (game.Board.AvailablePinCount() > 1)
            {
                Console.WriteLine();
                boardRenderer.Render();
                move = game.CurrentPlayer().GetMove(game.Board);
                game.ApplyMove(move);
            }

            Console.WriteLine();
            boardRenderer.Render();

            Console.WriteLine();
            WriteLine($"{game.Winner.Name} is the winner!", ConsoleColor.Green);
            Console.WriteLine();

            Write("Play again? y", Console.ForegroundColor);
            Console.CursorLeft = Console.CursorLeft - 1;
            string playAgain = Console.ReadLine();

            return (!playAgain.Equals("n", StringComparison.InvariantCultureIgnoreCase) &&
                !playAgain.Equals("no", StringComparison.InvariantCultureIgnoreCase));
        }


        static public string GetPlayerName(string title)
        {
            string name;

            do
            {
                Write($"What is the name of {title} > ", ConsoleColor.White);
                name = Console.ReadLine();
            } while (!IsValidPlayerName(name));

            return name;
        }

        static public string GetBotPlayerName()
        {
            return "Francis";
        }

        static private bool IsValidPlayerName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        static private void PromptUser(string prompt)
        {
            Write(prompt, ConsoleColor.White);
        }

        static private void Write(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = originalColor;
        }

        static private void WriteLine(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }

        static private void WriteIntro()
        {
            WriteLine("<<<  Welcome to ZNim  >>>", ConsoleColor.Green);
            WriteLine("The game is laid out as a series of 5 rows where the first row has a single pin", Console.ForegroundColor);
            WriteLine("and each successive row has one additional pin. In our case each row is also ", Console.ForegroundColor);
            WriteLine("prefixed with a row number to aid in making moves:", Console.ForegroundColor);
            WriteLine("", Console.ForegroundColor);
            Write("1", ConsoleColor.White);
            WriteLine(" |", Console.ForegroundColor);
            Write("2", ConsoleColor.White);
            WriteLine(" | |", Console.ForegroundColor);
            Write("3", ConsoleColor.White);
            WriteLine(" | | |", Console.ForegroundColor);
            Write("4", ConsoleColor.White);
            WriteLine(" | | | |", Console.ForegroundColor);
            Write("5", ConsoleColor.White);
            WriteLine(" | | | | |", Console.ForegroundColor);
            WriteLine("", Console.ForegroundColor);
            WriteLine("For each turn you may cross out as many sequential pins as you like within", Console.ForegroundColor);
            WriteLine("a single row but and you may not cross out any pins twice.\n", Console.ForegroundColor);
            WriteLine("The object of the game is to force your opponent to cross out the last pin.", Console.ForegroundColor);
            WriteLine("Good luck!.", Console.ForegroundColor);
            WriteLine("", Console.ForegroundColor);
        }
    }
}
