using BackEnd.Moves;
using BackEnd.Utils;

namespace BackEnd.Game;

public class Move
{
    public virtual Position FromPosition { get; }
    public virtual Position ToPosition { get; }
    public virtual Enums.MoveType MoveType => Enums.MoveType.None;
    
    public Move( Position fromPosition, Position toPosition)
    {
        FromPosition = fromPosition;
        ToPosition = toPosition;
    }
}