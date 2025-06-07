using BackEnd.Utils;

namespace BackEnd.Moves;

public class Position
{
    public int Row { get; }
    public int Column { get; }

    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public Enums.PlayerColor GetSquareColor(int row, int col)
    {
        return (row + col) % 2 == 0 ? Enums.PlayerColor.Black : Enums.PlayerColor.White;
    }

}