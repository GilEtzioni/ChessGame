using BackEnd.Game;
using BackEnd.Moves;
using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class Rook : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.Rook;
    public override Enums.PlayerColor Color { get; }
    private Direction[] RookDirections = new Direction[]
    {
        Direction.Up,
        Direction.Right,
        Direction.Down,
        Direction.Left,
    };
    
    public Rook(Enums.PlayerColor color) 
    {
        Color = color;
    }
    
    public override IEnumerable<Move> GetAllValidMoves(Position fromPosition, Board board)
    {
        var positions = GetAllMovesInAllDirections(fromPosition, board, RookDirections);
        var moves = new List<Move>();

        foreach (Position position in positions)
        {
            var move = new Move(fromPosition, position);
            moves.Add(move);
        }

        return moves;
    }
}