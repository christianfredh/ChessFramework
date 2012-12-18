using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ChessFramework.Windows8App
{
    public class PieceElement : Grid
    {
        public PieceElement(Piece piece)
        {
            var uri = new Uri("ms-appx:/Assets/" + piece.Color + piece.GetType().Name + ".png", UriKind.Absolute);
            Children.Add(new Image { Source = new BitmapImage(uri) });
        }
    }
}