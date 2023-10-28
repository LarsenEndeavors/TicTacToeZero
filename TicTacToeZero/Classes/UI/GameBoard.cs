namespace TicTacToeZero.Classes.UI
{
    public interface GameBoard
    {
        public void Draw();
        public void Update(int boardPosition);
        public void NewGame();
        public bool GameOver();
        public void ClearTheScreen();
        //This doesn't account for more than 2 players, but for now meh
        public void SetPlayerSymbols(string playerOneSymbol);
        public void WinMessage();
        public string? RestartRequest();
    }
}