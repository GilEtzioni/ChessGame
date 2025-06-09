using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BackEnd.ChessMan;
using BackEnd.Utils;

namespace ChessGame
{
    public class Images
    {
        private static readonly Dictionary<Enums.ChessManType, ImageSource> whitesource = new()
        {
            { Enums.ChessManType.Pawn, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\white_pawn.png") },
            { Enums.ChessManType.King, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\white_king.png") },
            { Enums.ChessManType.Knight, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\white_knight.png") },
            { Enums.ChessManType.Bishop, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\white_bishop.png") },
            { Enums.ChessManType.Rook, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\white_rook.png") },
            { Enums.ChessManType.Queen, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\white_queen.png") },
        };
        
        private static readonly Dictionary<Enums.ChessManType, ImageSource> blacksource = new()
        {
            { Enums.ChessManType.Pawn, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\black_pawn.png") },
            { Enums.ChessManType.King, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\black_king.png") },
            { Enums.ChessManType.Knight, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\black_knight.png") },
            { Enums.ChessManType.Bishop, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\black_bishop.png") },
            { Enums.ChessManType.Rook, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\black_rook.png") },
            { Enums.ChessManType.Queen, LoadImage("C:\\Users\\ניב\\RiderProjects\\ChessGame\\FrontEnd\\Assets\\black_queen.png") },
        };

        private static ImageSource LoadImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath, UriKind.Absolute));
        }

        public static ImageSource? GetImage(Enums.PlayerColor color, Enums.ChessManType type)
        {
            return color switch
            {
                Enums.PlayerColor.White => whitesource.TryGetValue(type, out var whiteImg) ? whiteImg : null,
                Enums.PlayerColor.Black => blacksource.TryGetValue(type, out var blackImg) ? blackImg : null,
                _ => null
            };
        }

        public static ImageSource? GetImage(ChessMan? chessMan)
        {
            return chessMan == null ? null : GetImage(chessMan.Color, chessMan.Type);
        }

    }
}