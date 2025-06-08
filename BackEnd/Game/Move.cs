using BackEnd.Moves;

namespace BackEnd.Game;

public class Move
{
    public Position FromPosition { get; }
    public Position ToPosition { get; }

    public Move( Position fromPosition, Position toPosition)
    {
        FromPosition = fromPosition;
        ToPosition = toPosition;
    }

    public void MoveChessMan(Board board)
    {
        var chessMan = board.GetAt(FromPosition);
        board.SetAt(ToPosition, chessMan);
        board.SetAt(FromPosition, null);
    }
}