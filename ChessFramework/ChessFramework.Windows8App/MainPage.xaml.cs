using System;
using System.Collections.Generic;
using System.Linq;
using ChessFramework.Windows8App.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ChessFramework.Windows8App
{
    public sealed partial class MainPage : LayoutAwarePage
    {
        private Game _game;
        private readonly IDictionary<string, GridView> _squares = new Dictionary<string, GridView>(64);

        public MainPage()
        {
            InitializeComponent();
            Loaded += delegate { NewGame(); };
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

        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            NewGame();
            TopAppBar.IsOpen = false;
        }

        private void NewGame()
        {
            _game = new Game();

            // TODO: UI for choice
            _game.PromotionChoice = () => PromotionChoice.Knight;

            _game.Start();
            InitSquaresDictionary();
            RenderBoard(_game.Board);
        }

        private void InitSquaresDictionary()
        {
            _squares.Clear();
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

            _squares.Add("a6", A6);
            _squares.Add("b6", B6);
            _squares.Add("c6", C6);
            _squares.Add("d6", D6);
            _squares.Add("e6", E6);
            _squares.Add("f6", F6);
            _squares.Add("g6", G6);
            _squares.Add("h6", H6);

            _squares.Add("a5", A5);
            _squares.Add("b5", B5);
            _squares.Add("c5", C5);
            _squares.Add("d5", D5);
            _squares.Add("e5", E5);
            _squares.Add("f5", F5);
            _squares.Add("g5", G5);
            _squares.Add("h5", H5);

            _squares.Add("a4", A4);
            _squares.Add("b4", B4);
            _squares.Add("c4", C4);
            _squares.Add("d4", D4);
            _squares.Add("e4", E4);
            _squares.Add("f4", F4);
            _squares.Add("g4", G4);
            _squares.Add("h4", H4);

            _squares.Add("a3", A3);
            _squares.Add("b3", B3);
            _squares.Add("c3", C3);
            _squares.Add("d3", D3);
            _squares.Add("e3", E3);
            _squares.Add("f3", F3);
            _squares.Add("g3", G3);
            _squares.Add("h3", H3);

            _squares.Add("a2", A2);
            _squares.Add("b2", B2);
            _squares.Add("c2", C2);
            _squares.Add("d2", D2);
            _squares.Add("e2", E2);
            _squares.Add("f2", F2);
            _squares.Add("g2", G2);
            _squares.Add("h2", H2);

            _squares.Add("a1", A1);
            _squares.Add("b1", B1);
            _squares.Add("c1", C1);
            _squares.Add("d1", D1);
            _squares.Add("e1", E1);
            _squares.Add("f1", F1);
            _squares.Add("g1", G1);
            _squares.Add("h1", H1);
        }

        private void RenderBoard(Board board)
        {
            foreach (var positionKey in _squares.Keys)
            {
                var position = new SquareIdentifier(positionKey);
                var square = board[position];

                var gridView = _squares[positionKey];
                var element = gridView.Items.FirstOrDefault() as PieceElement;

                if (element != null)
                {
                    if (square.IsOccupied())
                    {
                        if (element.PieceType != square.Piece.GetType()
                            || element.Color != square.Piece.Color)
                        {
                            gridView.Items.Clear();
                            var pieceElement = new PieceElement(square.Piece);
                            gridView.Items.Add(pieceElement);
                        }
                    }
                    else
                    {
                        gridView.Items.Clear();
                    }
                }
                else if (square.IsOccupied())
                {
                    var pieceElement = new PieceElement(square.Piece);
                    gridView.Items.Add(pieceElement);
                }
            }
        }

        private void OnDragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            _draggedFrom = sender as GridView;
            _draggedPiece = e.Items.OfType<PieceElement>().First();
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            try
            {
                var grid = (GridView)sender;
                var from = new SquareIdentifier(_draggedFrom.Name.ToLower());
                var to = new SquareIdentifier(grid.Name.ToLowerInvariant());
                _game.Move(from, to);

                _draggedFrom.Items.Remove(_draggedPiece);
                grid.Items.Clear();
                grid.Items.Add(new PieceElement(_game.Board[to].Piece));
                RenderBoard(_game.Board);
            }
            catch (IllegalMoveException)
            {
                // Don't make drop
            }
        }

        private GridView _draggedFrom;
        private PieceElement _draggedPiece;
    }
}
