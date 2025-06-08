using BackEnd.Game;
using BackEnd.Moves;
using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class Queen : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.Queen;
    public override Enums.PlayerColor Color { get; }
    
    private Direction[] QueenDirections = new Direction[]
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
    public Queen(Enums.PlayerColor color) 
    {
        Color = color;
    }
    
    public override IEnumerable<Move> GetAllValidMoves(Position fromPosition, Board board)
    {
        var positions = GetAllMovesInAllDirections(fromPosition, board, QueenDirections);
        var moves = new List<Move>();

        foreach (Position position in positions)
        {
            var move = new Move(fromPosition, position);
            moves.Add(move);
        }

        return moves;
    }
}