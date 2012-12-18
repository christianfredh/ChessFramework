using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ChessFramework.Windows8App.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ChessFramework.Windows8App
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MainPage : ChessFramework.Windows8App.Common.LayoutAwarePage
    {
        private readonly Game _game = new Game();
        private readonly IDictionary<string, Grid> _squares = new Dictionary<string, Grid>(64);

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            _game.Start();
            InitSquaresDictionary();
            RenderBoard(_game.Board);
        }

        private void InitSquaresDictionary()
        {
            _squares.Add("a8", A8);
            _squares.Add("b8", B8);
            _squares.Add("c8", C8);
            _squares.Add("d8", D8);
            _squares.Add("e8", E8);
            _squares.Add("f8", F8);
            _squares.Add("g8", G8);
            _squares.Add("h8", H8);

            _squares.Add("a7", A7);
            _squares.Add("b7", B7);
            _squares.Add("c7", C7);
            _squares.Add("d7", D7);
            _squares.Add("e7", E7);
            _squares.Add("f7", F7);
            _squares.Add("g7", G7);
            _squares.Add("h7", H7);
        }

        private void RenderBoard(Board board)
        {
            foreach (var positionKey in _squares.Keys)
            {
                var position = new Position(positionKey);
                var square = board[position];

                if (_squares[positionKey].Children.Count > 1)
                {
                    _squares[positionKey].Children.RemoveAt(1);
                }

                if (square.IsOccupied())
                {
                    var pieceElement = GetUIElementForPiece(square.Piece);
                    _squares[positionKey].Children.Add(pieceElement);
                }
            }
        }

        private static UIElement GetUIElementForPiece(Piece piece)
        {
            return new PieceElement(piece.Color, piece.GetType());
        }
    }

    public class PieceElement : Grid
    {
        public PieceElement(Army army, Type pieceType)
        {
            var uri = new Uri("ms-appx:/Assets/" + army + pieceType.Name + ".png", UriKind.Absolute);
            Children.Add(new Image { Source = new BitmapImage(uri) });
        }
    }
}
