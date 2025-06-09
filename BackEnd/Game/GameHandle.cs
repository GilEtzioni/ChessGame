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
}