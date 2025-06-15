using System;
using System.Windows;
using System.Windows.Controls;
using BackEnd.Game;
using BackEnd.Utils;

namespace ChessGame
{
    public partial class GameOverCard : UserControl
    {
        public event Action<GameOptions> OptionSelected;

        public GameOverCard()
        {
            InitializeComponent();
        }

        public void SetResult(GameHandle gameHandle)
        {
            Enums.PlayerColor result = gameHandle.GetWinner();
            WinnerText.Text = GetWinneText(result);
            ReasonText.Text = GetReasonText(result);
        }

        public static string GetWinneText(Enums.PlayerColor winner)
        {
            return winner switch
            {
                Enums.PlayerColor.Black => "Black Won!",
                Enums.PlayerColor.White => "White Won!",
                _ => "Draw!"
            };
        }

        private static string GetReasonText(Enums.PlayerColor winner)
        {
            return winner switch
            {
                Enums.PlayerColor.Black => "Black Won!",
                Enums.PlayerColor.White => "White Won!",
                _ => "Stalemate or Draw"
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(GameOptions.RestartGame);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(GameOptions.ExitGame);
        }
    }
}