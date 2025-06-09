using BackEnd.ChessMan;
using BackEnd.Moves;
using BackEnd.Utils;

namespace BackEnd.Game;

public class PawnPromotion : Move
{
    public override Enums.MoveType MoveType => Enums.MoveType.PawnPromotion;
    private readonly Enums.ChessManType newType;

    public PawnPromotion(Position fromPosition, Position toPosition, Enums.ChessManType newType)
        : base(fromPosition, toPosition)
    {
        this.newType = newType;
    }

    public ChessMan.ChessMan CreatePromotionChessMan(Enums.PlayerColor color)
    {
        if (newType == Enums.ChessManType.Knight)
            return new Knight(color);
        else if (newType == Enums.ChessManType.Queen)
            return new Queen(color);
        else if (newType == Enums.ChessManType.Rook)
            return new Rook(color);
        else if (newType == Enums.ChessManType.Bishop)
            return new Bishop(color);
        else
            throw new Exception($"Invalid promotion type: {newType}");
    }
}