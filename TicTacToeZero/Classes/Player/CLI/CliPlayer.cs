using System.Collections.Generic;

namespace TicTacToeZero.Classes.Player.CLI
{
    public class CliPlayer : Player
    {
        private string Symbol { get; set; }
        private List<int> SelectedSpots { get; set; } = new();
        private int PlayerNumber { get; set; }

        public CliPlayer(int playerNumber)
        {
            PlayerNumber = playerNumber;
        }
        
        public string GetSymbol()
        {
            return Symbol;
        }

        public void SetSymbol(string symbol)
        {
            Symbol = symbol;
        }

        public List<int> GetSelectedSpots()
        {
            return SelectedSpots;
        }

        public void AddSelectedSpot(int spot)
        {
            SelectedSpots.Add(spot);
        }

        public int GetPlayerNumber()
        {
            return PlayerNumber;
        }
    }
}