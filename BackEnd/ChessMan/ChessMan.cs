using BackEnd.Utils;

namespace BackEnd.ChessMan;

public abstract class ChessMan
{
    public abstract Enums.ChessManType Type { get; }
    public abstract Enums.PlayerColor Color { get; }
}