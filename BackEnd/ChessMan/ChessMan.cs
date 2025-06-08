using BackEnd.Game;
using BackEnd.Moves;
using BackEnd.Utils;

namespace BackEnd.ChessMan;

public abstract class ChessMan
{
    public abstract Enums.ChessManType Type { get; }
    public abstract Enums.PlayerColor Color { get; }
    public abstract IEnumerable<Move> GetAllValidMoves(Position fromPosition, Board board);
    
    // hepler function - get one direction(like up-left)
    // the function returan a list with all the steps that the ChessMan can do in that direction
    public List<Position> GetAllMovesInOneDirection(Position fromPosition, Board board, Direction direction)
    {
        var result = new List<Position>();

        int row = fromPosition.Row + direction.Row;
        int col = fromPosition.Column + direction.Column;

        while (row >= 0 && col >= 0 && row < 8 && col < 8)
        {
            var cell = board.GetAt(row, col);

            if (cell == null)
            {
                result.Add(new Position(row, col));
            }
            else
            {
                if (cell.Color != board.GetAt(fromPosition).Color)
                {
                    result.Add(new Position(row, col)); 
                }
                break;
            }
            row += direction.Row;
            col += direction.Column;
        }
        
        return result;
    }
    public List<Position> GetAllMovesInAllDirections(Position fromPosition, Board board, Direction[] directions)
    {
        var result = new List<Position>();
        foreach (Direction direction in directions)
        {
            var currDirectionMoves = GetAllMovesInOneDirection(fromPosition, board, direction);
            result.AddRange(currDirectionMoves);
        }
        return result;
    }
}