using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class King : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.King;
    public override Enums.PlayerColor Color { get; }
    
    public King(Enums.PlayerColor color) 
    {
        Color = color;
    }
}