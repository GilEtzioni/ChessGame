using BackEnd.Utils;

namespace BackEnd.ChessMan;

public class Pawn : ChessMan
{
    public override Enums.ChessManType Type => Enums.ChessManType.Pawn;
    public override Enums.PlayerColor Color { get; }
    
    public Pawn(Enums.PlayerColor color) 
    {
        Color = color;
    }
}