using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class Rook : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.Rook;
    public override Enums.PlayerColor Color { get; }
    
    public Rook(Enums.PlayerColor color) 
    {
        Color = color;
    }
}