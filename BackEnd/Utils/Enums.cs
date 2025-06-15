namespace BackEnd.Utils;

public class Enums
{
    public enum PlayerColor
    {
        Black,
        White,
        None
    }

    public enum ChessManType
    {
        Pawn,
        Rook,
        Knight,
        Bishop,
        Queen,
        King
    }

    public enum MoveType
    {
        None,
        PawnPromotion
    }
}