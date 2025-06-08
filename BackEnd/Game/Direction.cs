namespace BackEnd.Game;

public class Direction
{
    public int Row { get; }
    public int Column { get; }

    private Direction(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public static Direction operator +(Direction a, Direction b)
    {
        return new Direction(a.Row + b.Row, a.Column + b.Column);
    }

    public static readonly Direction Up = new Direction(-1, 0);
    public static readonly Direction Down = new Direction(1, 0);
    public static readonly Direction Left = new Direction(0, -1);
    public static readonly Direction Right = new Direction(0, 1);

    public static readonly Direction UpLeft = Up + Left;
    public static readonly Direction UpRight = Up + Right;
    public static readonly Direction DownLeft = Down + Left;
    public static readonly Direction DownRight = Down + Right;
    
    // knight directions
    public static readonly Direction UpUpRight = Up + Up + Right;
    public static readonly Direction UpUpLeft = Up + Up + Left;
    public static readonly Direction UpRightRight = Up + Right + Right;
    public static readonly Direction UpLeftLeft = Up + Left + Left;
    public static readonly Direction DownDownRight = Down + Down + Right;
    public static readonly Direction DownDownLeft = Down + Down + Left;
    public static readonly Direction DownRightRight = Down + Right + Right;
    public static readonly Direction DownLeftLeft = Down + Left + Left;
}