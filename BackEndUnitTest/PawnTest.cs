using BackEnd.Moves;
using NUnit.Framework;
using BackEnd.Game;
using BackEnd.Utils;
using BackEnd.ChessMan;
using System.Linq;

namespace BackEndUnitTest;

[TestFixture]
public class PawnTests
{
    [Test]
    public void Pawn_CanMoveOneStepForward()
    {
        var board = new Board();
        var pawn = new Pawn(Enums.PlayerColor.White);
        var position = new Position(3, 3);
        board.SetAt(position, pawn);

        var moves = pawn.GetAllValidMoves(position, board).ToList();

        Assert.That(moves.Any(m => m.ToPosition.Row == 4 && m.ToPosition.Column == 3), Is.True);
    }

    [Test]
    public void Pawn_CanMoveTwoStepsForward_IfFirstMove()
    {
        var board = new Board();
        var pawn = new Pawn(Enums.PlayerColor.White);
        var position = new Position(1, 3);
        board.SetAt(position, pawn);

        var moves = pawn.GetAllValidMoves(position, board).ToList();

        Assert.That(moves.Any(m => m.ToPosition.Row == 3 && m.ToPosition.Column == 3), Is.True);
    }

    [Test]
    public void Pawn_CannotMoveIfBlocked()
    {
        var board = new Board();
        var pawn = new Pawn(Enums.PlayerColor.White);
        var blocker = new Pawn(Enums.PlayerColor.White);

        var position = new Position(3, 3);
        var blockPos = new Position(4, 3);

        board.SetAt(position, pawn);
        board.SetAt(blockPos, blocker);

        var moves = pawn.GetAllValidMoves(position, board).ToList();

        Assert.That(moves.Any(m => m.ToPosition.Row == 4 && m.ToPosition.Column == 3), Is.False);
    }

    [Test]
    public void Pawn_CanCaptureDiagonally()
    {
        var board = new Board();
        var whitePawn = new Pawn(Enums.PlayerColor.White);
        var blackPawn = new Pawn(Enums.PlayerColor.Black);

        var position = new Position(3, 3);
        var enemyLeft = new Position(4, 2);
        var enemyRight = new Position(4, 4);

        board.SetAt(position, whitePawn);
        board.SetAt(enemyLeft, blackPawn);
        board.SetAt(enemyRight, blackPawn);

        var moves = whitePawn.GetAllValidMoves(position, board).ToList();

        Assert.That(moves.Any(m => m.ToPosition.Row == 4 && m.ToPosition.Column == 2), Is.True);
        Assert.That(moves.Any(m => m.ToPosition.Row == 4 && m.ToPosition.Column == 4), Is.True);
    }

    [Test]
    public void Pawn_CannotCaptureSameColorDiagonally()
    {
        var board = new Board();
        var whitePawn = new Pawn(Enums.PlayerColor.White);
        var whitePawn2 = new Pawn(Enums.PlayerColor.White);

        var position = new Position(3, 3);
        var sameColor = new Position(4, 2);

        board.SetAt(position, whitePawn);
        board.SetAt(sameColor, whitePawn2);

        var moves = whitePawn.GetAllValidMoves(position, board).ToList();

        Assert.That(moves.Any(m => m.ToPosition.Row == 4 && m.ToPosition.Column == 2), Is.False);
    }
}
