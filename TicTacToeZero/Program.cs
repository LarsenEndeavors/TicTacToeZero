#nullable enable
using System;
using TicTacToeZero.Classes.UI.CLI;

namespace TicTacToeZero
{
    class Program
    {
        static void Main(string[] args)
        {

            var board = new CliGameBoard();
            board.NewGame();
            board.Draw();

            Console.WriteLine("Who Goes First? (X or O)");
            var userInput = "";
            while (userInput != "X" && userInput != "O")
            {
                userInput = Console.ReadLine();
            }
            
            board.SetPlayerSymbols(userInput);
            userInput = "";
            while (userInput.ToLower() != "q" && !board.GameOver())
            {
                userInput = null;
                Console.WriteLine("Choose a slot");
                while (userInput == null)
                {
                    userInput = Console.ReadLine();
                }
                
                board.Update(int.Parse(userInput));
            }

            if (board.GameOver())
            {
                board.WinMessage();
                board.RestartRequest();
            }
        }
    }
}