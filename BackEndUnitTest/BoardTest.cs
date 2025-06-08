using NUnit.Framework;
using BackEnd.Game; 

namespace BackEndUnitTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void PrintBoard_Debug()
    {
        var board = new Board().Initial();
        board.PrintBoardToTerminal();
        Assert.Pass();
    }
}