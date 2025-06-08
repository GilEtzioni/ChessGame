using BackEnd.Game;
using BackEnd.Moves;
using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class King : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.King;
    public override Enums.PlayerColor Color { get; }
    private Direction[]Kingirections = new Direction[]
    {
        Direction.Up,
        Direction.Right,
        Direction.Down,
        Direction.Left,
        Direction.DownLeft,
        Direction.DownRight,
        Direction.UpLeft,
        Direction.UpRight
    };
    public King(Enums.PlayerColor color) 
    {
        Color = color;
    }
    
    public override IEnumerable<Move> GetAllValidMoves(Position fromPosition, Board board)
    {
        var moves = new List<Move>();

        foreach (Direction direction in Kingirections)
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