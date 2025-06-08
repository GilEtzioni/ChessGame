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

            boardUIHelper = new BoardUIHelper(gameHandle, ChessManGrid, MarkersGrid, BoardGrid);
            boardUIHelper.DrawBoard(gameHandle.Board);
        }

        private void BoardGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            boardUIHelper.OnMouseDown(sender, e);
        }
    }
}