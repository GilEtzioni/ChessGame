using System.Windows;
using System.Windows.Input;
using BackEnd.Game;
using BackEnd.Utils;

namespace ChessGame
{
    public partial class MainWindow : Window
    {
        private GameHandle gameHandle;
        private BoardUIHelper boardUIHelper;

        public MainWindow()
        {
            InitializeComponent();

            var board = Board.Initial();
            gameHandle = new GameHandle(Enums.PlayerColor.White, board);
            
            boardUIHelper = new BoardUIHelper(gameHandle, ChessManGrid, MarkersGrid, BoardGrid, MenuContainer);
            boardUIHelper.DrawBoard(gameHandle.Board);
        }

        private void BoardGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            boardUIHelper.OnMouseDown(sender, e);

            Enums.PlayerColor winner = gameHandle.GetWinner();
            if (winner != Enums.PlayerColor.None)
            {
                GameOverCard.SetResult(gameHandle);
                GameOverCard.Visibility = Visibility.Visible;
            }
        }
        
        private void GameOverCard_OptionSelected(GameOptions option)
        {
            if (option == GameOptions.RestartGame)
            {
                RestartGame();
            }
            else if (option == GameOptions.ExitGame)
            {
                Application.Current.Shutdown();
            }
        }
        
        private void RestartGame()
        {
            GameOverCard.Visibility = Visibility.Collapsed;

            var board = Board.Initial();
            gameHandle = new GameHandle(Enums.PlayerColor.White, board);

            boardUIHelper = new BoardUIHelper(gameHandle, ChessManGrid, MarkersGrid, BoardGrid, MenuContainer);
            boardUIHelper.DrawBoard(gameHandle.Board);
        }
    }
}