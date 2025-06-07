using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class Knight : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.Knight;
    public override Enums.PlayerColor Color { get; }
    
    public Knight(Enums.PlayerColor color) 
    {
        Color = color;
    }
}