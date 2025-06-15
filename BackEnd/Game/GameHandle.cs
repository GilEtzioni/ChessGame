using BackEnd.ChessMan;
using BackEnd.Moves;
using BackEnd.Utils;

namespace BackEnd.Game;

public class GameHandle
{
    public Board Board { get; set; }
    public Enums.PlayerColor CurrentPlayerColor { get; private set; }

    public GameHandle(Enums.PlayerColor currentPlayerColor, Board board)
    {
        CurrentPlayerColor = currentPlayerColor;
        Board = board;
    }

    public IEnumerable<Move> GetLegalMovesForChessMan(Position position)
    {
        var piece = Board.GetAt(position);
        if (piece == null || piece.Color != CurrentPlayerColor)
            return Enumerable.Empty<Move>();

        return piece.GetAllValidMoves(position, Board);
    }

    public void MakeMove(Move move)
    {
        ChessMan.ChessMan chessMan = Board.GetAt(move.FromPosition);
        Board.SetAt(move.ToPosition, chessMan);
        Board.SetAt(move.FromPosition, null);
        // switch turn
        CurrentPlayerColor = CurrentPlayerColor == Enums.PlayerColor.White
            ? Enums.PlayerColor.Black
            : Enums.PlayerColor.White;
    }
    public void SwitchTurn()
    {
        CurrentPlayerColor = CurrentPlayerColor == Enums.PlayerColor.White
            ? Enums.PlayerColor.Black
            : Enums.PlayerColor.White;
    }

    public Enums.PlayerColor GetWinner()
    {
        const int rows = 8;
        const int cols = 8;
        bool isWhiteKing = false;
        bool isBlackKing = false;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                var piece = Board.GetAt(i, j);
                if (piece is King king)
                {
                    if (king.Color == Enums.PlayerColor.Black)
                        isBlackKing = true;
                    else if (king.Color == Enums.PlayerColor.White)
                        isWhiteKing = true;
                }
            }
        }

        if (isWhiteKing && isBlackKing)
            return Enums.PlayerColor.None;
        else if (isWhiteKing)
            return Enums.PlayerColor.White;
        else
            return Enums.PlayerColor.Black;
    }

}