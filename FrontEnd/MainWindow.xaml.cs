using System.Windows;
using BackEnd.Game;
using BackEnd.Utils;

namespace ChessGame
{
    public partial class MainWindow : Window
    {
        private GameHandle gameHandle;

        public MainWindow()
        {
            InitializeComponent();

            var board = Board.Initial();
            gameHandle = new GameHandle(Enums.PlayerColor.White, board);

            BoardUIHelper.InitializeBoard(ChessManGrid);
            BoardUIHelper.DrawBoard(ChessManGrid, gameHandle.Board);
        }
    }
}