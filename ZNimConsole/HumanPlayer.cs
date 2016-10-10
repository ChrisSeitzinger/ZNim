using System;
using ZNim.Core;

namespace ZNim.Client
{
    public class HumanPlayer : Player
    {
        private BoardRenderer renderer;

        public HumanPlayer(string name, BoardRenderer renderer) : base(name)
        {
            this.renderer = renderer;
        }

        public override Move GetMove(Board board)
        {
            Move move = null;
            bool isValidMove = false;

            Write(Name, ConsoleColor.Green);
            WriteLine($", it's your move.", Console.ForegroundColor);

            do
            {
                int rowIndex = GetRow(board, "Enter Row> ");
                renderer.SelectRow(rowIndex);

                int firstPinIndex = GetFirstPin(board, rowIndex, "Enter First Pin> ");
                renderer.SelectPins(rowIndex, firstPinIndex, 1);

                int pinCount = GetPinCount(board, rowIndex, firstPinIndex, "Enter Number of Pins> ");
                renderer.SelectPins(rowIndex, firstPinIndex, pinCount);

                if (GetShouldApplyMove())
                {
                    move = new Move(rowIndex, firstPinIndex, pinCount);
                    isValidMove = board.IsValidMove(move);

                    if (!isValidMove)
                    {
                        Console.WriteLine();
                        PromptUser($"Sorry {Name}. That is not a valid move. Please try again.");
                        renderer.Render();
                    }
                }

                renderer.ClearSelection();

            } while (!isValidMove);

            return move;
        }

        private int GetRow(Board board, string prompt)
        {
            int rowIndex = -1;
            do
            {
                try
                {
                    rowIndex = GetIntegerInput(prompt) - 1;
                }
                catch
                {
                    WriteLine("Please enter a valid Row index.", ConsoleColor.DarkMagenta);
                }
            } while (!board.IsValidRow(rowIndex));
            return rowIndex;
        }

        private int GetFirstPin(Board board, int rowIndex, string prompt)
        {
            int firstPinIndex = -1;
            do
            {
                try
                {
                    firstPinIndex = GetIntegerInput(prompt) - 1;
                }
                catch
                {
                    WriteLine("Please enter a valid Row index.", ConsoleColor.DarkMagenta);
                }
            } while (!board.IsValidStartPin(rowIndex, firstPinIndex));
            return firstPinIndex;
        }

        private int GetPinCount(Board board, int rowIndex, int firstPinIndex, string prompt)
        {
            int length = -1;
            do
            {
                try
                {
                    length = GetIntegerInput(prompt);
                }
                catch
                {
                    WriteLine("Please enter a valid Row index.", ConsoleColor.DarkMagenta);
                }
            } while (!board.IsValidPinCount(rowIndex, firstPinIndex, length));
            return length;
        }

        private int GetIntegerInput(string prompt)
        {
            PromptUser(prompt);
            string input = Console.ReadLine();
            int number = Convert.ToInt32(input);
            return number;
        }

        private bool GetShouldApplyMove()
        {
            bool shouldApplyMove = true;
            bool answered = false;
            do
            {
                PromptUser("Apply the highlighted move? y");
                Console.CursorLeft = Console.CursorLeft - 1;
                string input = Console.ReadLine();

                switch (input)
                {
                    case "y":
                    case "t":
                    case "":
                        answered = true;
                        shouldApplyMove = true;
                        break;

                    case "n":
                    case "f":
                        answered = true;
                        shouldApplyMove = false;
                        break;
                }
            }
            while (!answered);

            return shouldApplyMove;
        }

        private void Write(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = originalColor;
        }

        private void WriteLine(string message, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = originalColor;
        }

        private void PromptUser(string prompt)
        {
            Write(prompt, ConsoleColor.White);
        }
    }
}
