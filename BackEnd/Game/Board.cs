using BackEnd.ChessMan;
using BackEnd.Moves;
using BackEnd.Utils;

namespace BackEnd.Game;

public class Board
{
    private readonly ChessMan.ChessMan[,] chessMans = new ChessMan.ChessMan[8, 8];

    public ChessMan.ChessMan GetAt(int row, int col)
    {
        return chessMans[row, col];
    }
    
    public ChessMan.ChessMan GetAt(Position position)
    {
        return chessMans[position.Row, position.Column];
    }

    public void SetAt(int row, int col, ChessMan.ChessMan value)
    {
        chessMans[row, col] = value;
    }
    
    public void SetAt(Position position, ChessMan.ChessMan value)
    {
        chessMans[position.Row, position.Column] = value;
    }

    public Board Initial()
    {
        Board board = new Board();
        board.AddStarterChessManToBoard();
        return board;
    }
    public void AddStarterChessManToBoard()
    {
        // black i=0
        this.SetAt(0, 0, new Rook(Enums.PlayerColor.Black));
        this.SetAt(0, 1, new Knight(Enums.PlayerColor.Black));
        this.SetAt(0, 2, new Bishop(Enums.PlayerColor.Black));
        this.SetAt(0, 3, new Queen(Enums.PlayerColor.Black));
        this.SetAt(0, 4, new King(Enums.PlayerColor.Black));
        this.SetAt(0, 5, new Bishop(Enums.PlayerColor.Black));
        this.SetAt(0, 6, new Knight(Enums.PlayerColor.Black));
        this.SetAt(0, 7, new Rook(Enums.PlayerColor.Black));
        
        // white i=7
        this.SetAt(7, 0, new Rook(Enums.PlayerColor.White));
        this.SetAt(7, 1, new Knight(Enums.PlayerColor.White));
        this.SetAt(7, 2, new Bishop(Enums.PlayerColor.White));
        this.SetAt(7, 3, new Queen(Enums.PlayerColor.White));
        this.SetAt(7, 4, new King(Enums.PlayerColor.White));
        this.SetAt(7, 5, new Bishop(Enums.PlayerColor.White));
        this.SetAt(7, 6, new Knight(Enums.PlayerColor.White));
        this.SetAt(7, 7, new Rook(Enums.PlayerColor.White));
        
        // black i=1 && white i=6
        for (int i = 0; i < 8; i++)
        {
            this.SetAt(1,i, new Pawn(Enums.PlayerColor.Black));
            this.SetAt(6,i, new Pawn(Enums.PlayerColor.White));
        }
    }
    
    // helper function - will be used only for debuging
    public void PrintBoardToTerminal()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                ChessMan.ChessMan itemChessMan = GetAt(row, col);
                if (itemChessMan != null)
                {
                    string type = itemChessMan.GetType().Name.Substring(0, 2);
                    string color = itemChessMan.Color == Enums.PlayerColor.White ? "W" : "B";
                    Console.Write($"{type}{color} ");
                }
                else
                {
                    Console.Write("--- ");
                }
            }
            Console.WriteLine();
        }
    }

}