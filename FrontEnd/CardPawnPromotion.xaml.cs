using System.Windows.Controls;
using System.Windows.Input;
using BackEnd.ChessMan;
using BackEnd.Utils;

namespace ChessGame;

public partial class CardPawnPromotion : UserControl
{
    public event Action<Enums.ChessManType> ChessManSelected;
    
    public CardPawnPromotion(ChessMan chessMan)
    {
        InitializeComponent();
        QueenPNG.Source = Images.GetImage(chessMan.Color, Enums.ChessManType.Queen);
        BishopPNG.Source = Images.GetImage(chessMan.Color, Enums.ChessManType.Bishop);
        RookPNG.Source = Images.GetImage(chessMan.Color, Enums.ChessManType.Rook);
        KnightPNG.Source = Images.GetImage(chessMan.Color, Enums.ChessManType.Knight);
    }
    private void QueenPNG_MouseDown(object sender, MouseButtonEventArgs e)
    {
        ChessManSelected?.Invoke(Enums.ChessManType.Queen);
    }

    private void BishopPNG_MouseDown(object sender, MouseButtonEventArgs e)
    {
        ChessManSelected?.Invoke(Enums.ChessManType.Bishop);
    }

    private void RookPNG_MouseDown(object sender, MouseButtonEventArgs e)
    {
        ChessManSelected?.Invoke(Enums.ChessManType.Rook);
    }

    private void KnightPNG_MouseDown(object sender, MouseButtonEventArgs e)
    {
        ChessManSelected?.Invoke(Enums.ChessManType.Knight);
    }
}