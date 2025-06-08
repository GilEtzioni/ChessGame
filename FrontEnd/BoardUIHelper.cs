using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using BackEnd.ChessMan;
using BackEnd.Game;
using BackEnd.Utils;

namespace ChessGame
{
    public static class BoardUIHelper
    {
        private static readonly Image[,] chessManImages = new Image[8, 8];
        private static readonly Images _images = new Images();

        public static void InitializeBoard(UniformGrid chessManGrid)
        {
            chessManGrid.Children.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Image image = new Image();
                    chessManImages[i, j] = image;
                    chessManGrid.Children.Add(image);
                }
            }
        }

        public static void DrawBoard(UniformGrid chessManGrid, Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ChessMan? chessMan = board.GetAt(i, j);
                    chessManImages[i, j].Source = _images.GetImage(chessMan);
                }
            }
        }
    }
}