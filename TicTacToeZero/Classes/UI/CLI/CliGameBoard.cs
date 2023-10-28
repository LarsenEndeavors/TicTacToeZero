using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeZero.Classes.Player.CLI;

namespace TicTacToeZero.Classes.UI.CLI
{
    public class CliGameBoard : GameBoard
    {
        public CliGameBoard()
        {
            
        }

        private Dictionary<int, string> BoardDictionary { get; set; } = new();
        private int Columns { get; set; } = 3;
        private int Rows { get; set; } = 3;
        private int NumberOfPlayers { get; set; } = 2;
        private CliPlayer CurrentTurnPlayer { get; set; }
        private CliPlayer WinningPlayer { get; set; }
        private List<CliPlayer> Players { get; set; } = new();
        private int Turn { get; set; } = 0;

        public void Draw()
        {
            Console.WriteLine("Turn: " + Turn);
            Console.WriteLine(" _ _ _");
            var cursor = 1;
            for (var i = 0; i < Rows; i++)
            {
                Console.Write("|");
                for (var j = 0; j < Columns; j++)
                {
                    Console.Write(BoardDictionary[cursor] + "|");
                    cursor++;
                }
                Console.Write("\n");
            }
            Console.WriteLine(" _ _ _");
        }
        
        public void SetPlayerSymbols(string playerOneSymbol)
        {
            if (playerOneSymbol.ToUpper() == "X" || playerOneSymbol.ToUpper() == "O")
            {
                Players[0].SetSymbol(playerOneSymbol);
                Players[1].SetSymbol(playerOneSymbol == "X" ? "O" : "X");
            }
            else
            {
                NewGame();
                ClearTheScreen();
                Draw();
            }
        }

        public void WinMessage()
        {
            Console.WriteLine(WinningPlayer.GetSymbol() + " wins!");
        }

        public string? RestartRequest()
        {
            Console.WriteLine("Would you like to try again?  R - Restart, Q - Quit");
            return Console.ReadLine();
        }

        public void Update(int boardPosition)
        {
            if (boardPosition > 0 && boardPosition < Rows * Columns)
            {
                BoardDictionary[boardPosition] = CurrentTurnPlayer.GetSymbol();
                CurrentTurnPlayer.AddSelectedSpot(boardPosition);
                CurrentTurnPlayer = CurrentTurnPlayer.GetPlayerNumber() == NumberOfPlayers
                    ? Players[0]
                    : Players[CurrentTurnPlayer.GetPlayerNumber()];
                Turn += 1;
            }
            
            ClearTheScreen();
            Draw();
        }

        public void ClearTheScreen()
        {
            Console.Clear();
        }

        public void NewGame()
        {
            BoardDictionary = new Dictionary<int, string>
            {
                { 1, "1" },
                { 2, "2" },
                { 3, "3" },
                { 4, "4" },
                { 5, "5" },
                { 6, "6" },
                { 7, "7" },
                { 8, "8" },
                { 9, "9" }
            };
            
            Players.Clear();
            for (var i = 0; i < NumberOfPlayers; i++)
            {
                Players.Add(new CliPlayer(i + 1));
            }

            CurrentTurnPlayer = Players[0];
        }

        public bool GameOver()
        {
            /*
             * Valid Combinations:
             * 1,2,3
             * 4,5,6
             * 7,8,9
             * 1,4,7
             * 2,5,8
             * 3,6,9
             * 1,5,9
             * 3,5,7
             */
            
            var winner = Players.Where(player => player.GetSelectedSpots().Count > 2 &&
                                         (player.GetSelectedSpots().Contains(1) &&
                                          player.GetSelectedSpots().Contains(2) &&
                                          player.GetSelectedSpots().Contains(3)) ||
                                         (player.GetSelectedSpots().Contains(4) &&
                                          player.GetSelectedSpots().Contains(5) &&
                                          player.GetSelectedSpots().Contains(6)) ||
                                         (player.GetSelectedSpots().Contains(7) &&
                                          player.GetSelectedSpots().Contains(8) &&
                                          player.GetSelectedSpots().Contains(9)) ||
                                         (player.GetSelectedSpots().Contains(1) &&
                                          player.GetSelectedSpots().Contains(4) &&
                                          player.GetSelectedSpots().Contains(7)) ||
                                         (player.GetSelectedSpots().Contains(2) &&
                                          player.GetSelectedSpots().Contains(5) &&
                                          player.GetSelectedSpots().Contains(8)) ||
                                         (player.GetSelectedSpots().Contains(3) &&
                                          player.GetSelectedSpots().Contains(6) &&
                                          player.GetSelectedSpots().Contains(9)) ||
                                         (player.GetSelectedSpots().Contains(1) &&
                                          player.GetSelectedSpots().Contains(5) &&
                                          player.GetSelectedSpots().Contains(9)) ||
                                         (player.GetSelectedSpots().Contains(3) &&
                                          player.GetSelectedSpots().Contains(5) &&
                                          player.GetSelectedSpots().Contains(7))).ToList();
            WinningPlayer = winner.Any() ? winner[0] : null;
            return WinningPlayer != null;
        }
    }
}