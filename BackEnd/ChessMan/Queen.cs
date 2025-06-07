using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class Queen : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.Queen;
    public override Enums.PlayerColor Color { get; }
    
    public Queen(Enums.PlayerColor color) 
    {
        Color = color;
    }
}