using BackEnd.Game;
using BackEnd.Moves;
using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class Knight : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.Knight;
    public override Enums.PlayerColor Color { get; }
    private Direction[] KnightDirections = new Direction[]
    {
        Direction.UpUpRight,
        Direction.UpUpLeft,
        Direction.UpRightRight,
        Direction.UpLeftLeft,
        Direction.DownDownRight, 
        Direction.DownDownLeft, 
        Direction.DownRightRight, 
        Direction.DownLeftLeft, 
    };
    public Knight(Enums.PlayerColor color) 
    {
        Color = color;
    }

    public override IEnumerable<Move> GetAllValidMoves(Position fromPosition, Board board)
    {
        var moves = new List<Move>();

        foreach (Direction direction in KnightDirections)
        {
            int newRow = fromPosition.Row + direction.Row;
            int newCol = fromPosition.Column + direction.Column;
            
            if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
            {
                var target = board.GetAt(newRow, newCol);
                if (target == null || target.Color != this.Color)
                {
                    Position toPosition = new Position(newRow, newCol);
                    moves.Add(new Move(fromPosition, toPosition));
                }
            }
        }

        return moves;
    }

}