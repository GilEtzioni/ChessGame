using BackEnd.Utils;

namespace BackEnd.Game;

public class GameHandle
{
    public Board Board { get; set; }
    public Enums.PlayerColor CurrentPlayerColor { get; private set; }

    public GameHandle(Enums.PlayerColor currentPlayerColor, Board board)
    {
        CurrentPlayerColor = currentPlayerColor;
        Board = board;
    }
}