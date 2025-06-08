using BackEnd.Game;
using BackEnd.Moves;
using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class Bishop : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.Bishop;
    public override Enums.PlayerColor Color { get; }

    private Direction[] BishopDirections = new Direction[]
    {
        Direction.DownLeft,
        Direction.DownRight,
        Direction.UpLeft,
        Direction.UpRight
    };

    public Bishop(Enums.PlayerColor color)
    {
        Color = color;
    }

    public override IEnumerable<Move> GetAllValidMoves(Position fromPosition, Board board)
    {
        var positions = GetAllMovesInAllDirections(fromPosition, board, BishopDirections);
        var moves = new List<Move>();

        foreach (Position position in positions)
        {
            var move = new Move(fromPosition, position);
            moves.Add(move);
        }

        return moves;
    }
}
