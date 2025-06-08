using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using BackEnd.ChessMan;
using BackEnd.Game;
using BackEnd.Moves;
using BackEnd.Utils;
using System.Windows;
using System.Diagnostics;

namespace ChessGame
{
    public class BoardUIHelper
    {
        private readonly Image[,] chessManImages = new Image[8, 8];
        private readonly Rectangle[,] markers = new Rectangle[8, 8];
        private readonly Dictionary<Position, Move> moveCache = new();
        private readonly Images _images = new();
        private Position? selectedPosition = null;

        private readonly GameHandle _gameHandle;
        private readonly UniformGrid _chessManGrid;
        private readonly UniformGrid _markersGrid;
        private readonly Grid _boardGrid;

        public BoardUIHelper(GameHandle gameHandle, UniformGrid chessManGrid, UniformGrid markersGrid, Grid boardGrid)
        {
            _gameHandle = gameHandle;
            _chessManGrid = chessManGrid;
            _markersGrid = markersGrid;
            _boardGrid = boardGrid;

            InitializeBoard();
        }

        private void InitializeBoard()
        {
            _chessManGrid.Children.Clear();
            _markersGrid.Children.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var image = new Image();
                    chessManImages[i, j] = image;
                    _chessManGrid.Children.Add(image);

                    var marker = new Rectangle
                    {
                        Fill = Brushes.Transparent,
                        IsHitTestVisible = false
                    };
                    markers[i, j] = marker;
                    _markersGrid.Children.Add(marker);
                }
            }
        }

        public void DrawBoard(Board board)
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

        public void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = e.GetPosition(_boardGrid);
            var position = ToSquarePosition(point);

            if (selectedPosition == null)
                OnFromPositionSelected(position);
            else
                OnToPositionSelected(position);
        }

        private void OnFromPositionSelected(Position position)
        {
            var moves = _gameHandle.GetLegalMovesForChessMan(position);
            if (moves.Any())
            {
                selectedPosition = position;
                CacheMoves(moves);
                ShowMarkers();
            }
        }


        private void OnToPositionSelected(Position position)
        {
            selectedPosition = null;
            HideMarkers();
            if (moveCache.TryGetValue(position, out var move))
            {
                HandleMove(move);
            }
        }

        private void HandleMove(Move move)
        {
            _gameHandle.MakeMove(move);
            DrawBoard(_gameHandle.Board);
        }

        private Position ToSquarePosition(Point point)
        {
            double squareSize = _boardGrid.ActualWidth / 8;
            int row = (int)(point.Y / squareSize);
            int col = (int)(point.X / squareSize);
            return new Position(row, col);
        }

        private void CacheMoves(IEnumerable<Move> moves)
        {
            moveCache.Clear();
            foreach (var move in moves)
            {
                moveCache[move.ToPosition] = move;
            }
        }

        private void ShowMarkers()
        {
            var color = Color.FromArgb(150, 125, 255, 125);
            foreach (var pos in moveCache.Keys)
            {
                markers[pos.Row, pos.Column].Fill = new SolidColorBrush(color);
            }
        }

        private void HideMarkers()
        {
            foreach (var pos in moveCache.Keys)
            {
                markers[pos.Row, pos.Column].Fill = Brushes.Transparent;
            }
        }
    }
}
