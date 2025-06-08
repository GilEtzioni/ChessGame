using NUnit.Framework;
using BackEnd.Game;
using BackEnd.Utils;
using BackEnd.ChessMan;
using System.Linq;
using BackEnd.Moves;

namespace BackEndUnitTest;

[TestFixture]
public class RookTests
{
    [Test]
    public void Rook_CanMoveHorizontally()
    {
        var board = new Board();
        var rook = new Rook(Enums.PlayerColor.White);
        var position = new Position(4, 4);
        board.SetAt(position, rook);

        var moves = rook.GetAllValidMoves(position, board).ToList();

        Assert.That(moves.Any(m => m.ToPosition.Row == 4 && m.ToPosition.Column == 0));
        Assert.That(moves.Any(m => m.ToPosition.Row == 4 && m.ToPosition.Column == 7));
    }

    [Test]
    public void Rook_CanMoveVertically()
    {
        var board = new Board();
        var rook = new Rook(Enums.PlayerColor.White);
        var position = new Position(4, 4);
        board.SetAt(position, rook);

        var moves = rook.GetAllValidMoves(position, board).ToList();

        Assert.That(moves.Any(m => m.ToPosition.Row == 0 && m.ToPosition.Column == 4));
        Assert.That(moves.Any(m => m.ToPosition.Row == 7 && m.ToPosition.Column == 4));
    }

    [Test]
    public void Rook_CannotJumpOverPieces()
    {
        var board = new Board();
        var rook = new Rook(Enums.PlayerColor.White);
        var blocker = new Pawn(Enums.PlayerColor.White);
        var position = new Position(4, 4);
        var blockPos = new Position(4, 6);

        board.SetAt(position, rook);
        board.SetAt(blockPos, blocker);

        var moves = rook.GetAllValidMoves(position, board).ToList();

        Assert.That(!moves.Any(m => m.ToPosition.Column > 5));
    }

    [Test]
    public void Rook_CanCaptureOpponent()
    {
        var board = new Board();
        var rook = new Rook(Enums.PlayerColor.White);
        var enemy = new Pawn(Enums.PlayerColor.Black);
        var position = new Position(4, 4);
        var enemyPos = new Position(4, 6);

        board.SetAt(position, rook);
        board.SetAt(enemyPos, enemy);

        var moves = rook.GetAllValidMoves(position, board).ToList();

        Assert.That(moves.Any(m => m.ToPosition.Equals(enemyPos)));
    }

    [Test]
    public void Rook_CannotCaptureSameColor()
    {
        var board = new Board();
        var rook = new Rook(Enums.PlayerColor.White);
        var friendly = new Pawn(Enums.PlayerColor.White);
        var position = new Position(4, 4);
        var friendPos = new Position(4, 5);

        board.SetAt(position, rook);
        board.SetAt(friendPos, friendly);

        var moves = rook.GetAllValidMoves(position, board).ToList();

        Assert.That(!moves.Any(m => m.ToPosition.Equals(friendPos)));
    }
}
