using BackEnd.Game;
using BackEnd.Moves;
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

    private IEnumerable<Move> PromotionMoves(Position fromPosition, Position toPosition)
    {
        var moves = new List<Move>
        {
            new PawnPromotion(fromPosition, toPosition, Enums.ChessManType.Bishop),
            new PawnPromotion(fromPosition, toPosition, Enums.ChessManType.Rook),
            new PawnPromotion(fromPosition, toPosition, Enums.ChessManType.Queen),
            new PawnPromotion(fromPosition, toPosition, Enums.ChessManType.Knight)
        };

        return moves;
    }
    
    public override IEnumerable<Move> GetAllValidMoves(Position fromPosition, Board board)
    {
        var moves = new List<Move>();

        // 1) two steps forward (only from starting position)
        moves.AddRange(MoveTwoStepsForward(fromPosition, board, Color));

        // 2) one step forward
        moves.AddRange(MoveOneStepForward(fromPosition, board, Color));

        // 3) move diagonal (kill opponent)
        moves.AddRange(MoveOneStepsDiagnol(fromPosition, board, Color));

        return moves;
    }

    private IEnumerable<Move> MoveTwoStepsForward(Position fromPosition, Board board, Enums.PlayerColor color)
    {
        var moves = new List<Move>();

        if (color == Enums.PlayerColor.Black &&
            fromPosition.Row == 1 &&
            board.GetAt(fromPosition.Row + 1, fromPosition.Column) == null &&
            board.GetAt(fromPosition.Row + 2, fromPosition.Column) == null)
        {
            var toPosition = new Position(fromPosition.Row + 2, fromPosition.Column);
            moves.Add(new Move(fromPosition, toPosition));
        }
        else if (color == Enums.PlayerColor.White &&
                 fromPosition.Row == 6 &&
                 board.GetAt(fromPosition.Row - 1, fromPosition.Column) == null &&
                 board.GetAt(fromPosition.Row - 2, fromPosition.Column) == null)
        {
            var toPosition = new Position(fromPosition.Row - 2, fromPosition.Column);
            moves.Add(new Move(fromPosition, toPosition));
        }

        return moves;
    }
    
    private IEnumerable<Move> MoveOneStepForward(Position fromPosition, Board board, Enums.PlayerColor color)
    {
        var moves = new List<Move>();

        if (color == Enums.PlayerColor.Black)
        {
            int newRow = fromPosition.Row + 1;
            if (newRow < 8 && board.GetAt(newRow, fromPosition.Column) == null)
            {
                Position toPosition = new Position(newRow, fromPosition.Column);

                if (newRow == 7)
                {
                    foreach (Move nextMove in PromotionMoves(fromPosition, toPosition))
                    {
                        moves.Add(nextMove);
                    }
                }
                else
                {
                    moves.Add(new Move(fromPosition, toPosition));
                }
            }
        }
        else if (color == Enums.PlayerColor.White)
        {
            int newRow = fromPosition.Row - 1;
            if (newRow >= 0 && board.GetAt(newRow, fromPosition.Column) == null)
            {
                Position toPosition = new Position(newRow, fromPosition.Column);

                if (newRow == 0)
                {
                    foreach (Move nextMove in PromotionMoves(fromPosition, toPosition))
                    {
                        moves.Add(nextMove);
                    }
                }
                else
                {
                    moves.Add(new Move(fromPosition, toPosition));
                }
            }
        }

        return moves;
    }

    private IEnumerable<Move> MoveOneStepsDiagnol(Position fromPosition, Board board, Enums.PlayerColor color)
    {
        var moves = new List<Move>();

        if (color == Enums.PlayerColor.Black)
        {
            int newRow = fromPosition.Row + 1;

            // diagonal left
            int leftCol = fromPosition.Column - 1;
            if (newRow < 8 && leftCol >= 0)
            {
                var target = board.GetAt(newRow, leftCol);
                if (target != null && target.Color != color)
                {
                    Position toPosition = new Position(newRow, leftCol);
                    if (newRow == 7)
                    {
                        moves.AddRange(PromotionMoves(fromPosition, toPosition));
                    }
                    else
                    {
                        moves.Add(new Move(fromPosition, toPosition));
                    }
                }
            }

            // diagonal right
            int rightCol = fromPosition.Column + 1;
            if (newRow < 8 && rightCol < 8)
            {
                var target = board.GetAt(newRow, rightCol);
                if (target != null && target.Color != color)
                {
                    Position toPosition = new Position(newRow, rightCol);
                    if (newRow == 7)
                    {
                        moves.AddRange(PromotionMoves(fromPosition, toPosition));
                    }
                    else
                    {
                        moves.Add(new Move(fromPosition, toPosition));
                    }
                }
            }
        }
        else if (color == Enums.PlayerColor.White)
        {
            int newRow = fromPosition.Row - 1;

            // diagonal left
            int leftCol = fromPosition.Column - 1;
            if (newRow >= 0 && leftCol >= 0)
            {
                var target = board.GetAt(newRow, leftCol);
                if (target != null && target.Color != color)
                {
                    Position toPosition = new Position(newRow, leftCol);
                    if (newRow == 0)
                    {
                        moves.AddRange(PromotionMoves(fromPosition, toPosition));
                    }
                    else
                    {
                        moves.Add(new Move(fromPosition, toPosition));
                    }
                }
            }

            // diagonal right
            int rightCol = fromPosition.Column + 1;
            if (newRow >= 0 && rightCol < 8)
            {
                var target = board.GetAt(newRow, rightCol);
                if (target != null && target.Color != color)
                {
                    Position toPosition = new Position(newRow, rightCol);
                    if (newRow == 0)
                    {
                        moves.AddRange(PromotionMoves(fromPosition, toPosition));
                    }
                    else
                    {
                        moves.Add(new Move(fromPosition, toPosition));
                    }
                }
            }
        }

        return moves;
    }
}