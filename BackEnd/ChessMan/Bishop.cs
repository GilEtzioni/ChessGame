using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class Bishop : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.Bishop;
    public override Enums.PlayerColor Color { get; }
    
    public Bishop(Enums.PlayerColor color) 
    {
        Color = color;
    }
}