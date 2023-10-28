using System.Collections.Generic;

namespace TicTacToeZero.Classes.Player
{
    public interface Player
    {
        public string GetSymbol();
        public void SetSymbol(string symbol);
        public List<int> GetSelectedSpots();
        public void AddSelectedSpot(int spot);
        public int GetPlayerNumber();
    }
}