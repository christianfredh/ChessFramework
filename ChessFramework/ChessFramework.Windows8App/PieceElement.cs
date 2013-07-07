using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ChessFramework.Windows8App
{
    public class PieceElement : Grid
    {
        public Type PieceType { get; set; }
        public Army Color { get; set; }

        public PieceElement(Piece piece)
        {
            PieceType = piece.GetType();
            Color = piece.Color;

            AddPieceImage();
        }

        private void AddPieceImage()
        {
            var uri = new Uri("ms-appx:/Assets/" + Color + PieceType.Name + ".png", UriKind.Absolute);
            Children.Add(new Image {Source = new BitmapImage(uri)});
        }
    }
}