using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class Board
    {
        private readonly Square[,] _squares = new Square[8, 8];

        public Board()
        {
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    _squares[i, j] = new Square();
                }
            }

            InitializePosition("a1", new Rook { Color = Army.White });
            InitializePosition("b1", new Knight { Color = Army.White });
            InitializePosition("c1", new Bishop { Color = Army.White });
            InitializePosition("d1", new Queen { Color = Army.White });
            InitializePosition("e1", new King { Color = Army.White });
            InitializePosition("f1", new Bishop { Color = Army.White });
            InitializePosition("g1", new Knight { Color = Army.White });
            InitializePosition("h1", new Rook { Color = Army.White });

            InitializePosition("a2", new Pawn { Color = Army.White });
            InitializePosition("b2", new Pawn { Color = Army.White });
            InitializePosition("c2", new Pawn { Color = Army.White });
            InitializePosition("d2", new Pawn { Color = Army.White });
            InitializePosition("e2", new Pawn { Color = Army.White });
            InitializePosition("f2", new Pawn { Color = Army.White });
            InitializePosition("g2", new Pawn { Color = Army.White });
            InitializePosition("h2", new Pawn { Color = Army.White });

            InitializePosition("a3", null);
            InitializePosition("b3", null);
            InitializePosition("c3", null);
            InitializePosition("d3", null);
            InitializePosition("e3", null);
            InitializePosition("f3", null);
            InitializePosition("g3", null);
            InitializePosition("h3", null);

            InitializePosition("a4", null);
            InitializePosition("b4", null);
            InitializePosition("c4", null);
            InitializePosition("d4", null);
            InitializePosition("e4", null);
            InitializePosition("f4", null);
            InitializePosition("g4", null);
            InitializePosition("h4", null);

            InitializePosition("a5", null);
            InitializePosition("b5", null);
            InitializePosition("c5", null);
            InitializePosition("d5", null);
            InitializePosition("e5", null);
            InitializePosition("f5", null);
            InitializePosition("g5", null);
            InitializePosition("h5", null);

            InitializePosition("a6", null);
            InitializePosition("b6", null);
            InitializePosition("c6", null);
            InitializePosition("d6", null);
            InitializePosition("e6", null);
            InitializePosition("f6", null);
            InitializePosition("g6", null);
            InitializePosition("h6", null);

            InitializePosition("a7", new Pawn { Color = Army.Black });
            InitializePosition("b7", new Pawn { Color = Army.Black });
            InitializePosition("c7", new Pawn { Color = Army.Black });
            InitializePosition("d7", new Pawn { Color = Army.Black });
            InitializePosition("e7", new Pawn { Color = Army.Black });
            InitializePosition("f7", new Pawn { Color = Army.Black });
            InitializePosition("g7", new Pawn { Color = Army.Black });
            InitializePosition("h7", new Pawn { Color = Army.Black });

            InitializePosition("a8", new Rook { Color = Army.Black });
            InitializePosition("b8", new Knight { Color = Army.Black });
            InitializePosition("c8", new Bishop { Color = Army.Black });
            InitializePosition("d8", new Queen { Color = Army.Black });
            InitializePosition("e8", new King { Color = Army.Black });
            InitializePosition("f8", new Bishop { Color = Army.Black });
            InitializePosition("g8", new Knight { Color = Army.Black });
            InitializePosition("h8", new Rook { Color = Army.Black });
        }

        public Square this[SquareIdentifier squareIdentifier]
        {
            get
            {
                var indicies = ToIndecies(squareIdentifier);
                return _squares[indicies.Item1, indicies.Item2];
            }
        }

        public IEnumerable<SquareIdentifier> AllPositions
        {
            get
            {
                for (var file = 'a'; file <= 'h'; file++)
                {
                    for (var rank = '1'; rank <= '8'; rank++)
                    {
                        yield return new SquareIdentifier(file, rank);
                    }
                }
            }
        }

        public IEnumerable<Square> Squares
        {
            get { return AllPositions.Select(p => this[p]); }
        }

        internal IEnumerable<Square> GetThretenedSquares(Army threatenedBy)
        {
            var pieces = from square in Squares
                         let piece = square.Piece
                         where piece != null && piece.Color == threatenedBy
                         select piece;

            var threatenedSquares = pieces
                .SelectMany(square => square.GetThreatenedSquares())
                .Distinct();

            return threatenedSquares;
        }

        internal Square GetKingSquare(Army color)
        {
            return Squares.First(s => s.Piece is King && s.Piece.Color == color);
        }

        internal bool IsInCheck(Army color)
        {
            var otherColor = color == Army.White ? Army.Black : Army.White;
            return GetThretenedSquares(otherColor)
                .Contains(GetKingSquare(color));
        }

        public bool IsOccupied(SquareIdentifier squareIdentifier)
        {
            return this[squareIdentifier].IsOccupied();
        }

        public bool IsFree(SquareIdentifier squareIdentifier)
        {
            return this[squareIdentifier].IsFree();
        }

        private void InitializePosition(string positionText, Piece piece)
        {
            var position = new SquareIdentifier(positionText);
            var square = this[position];
            square.Identifier = position;
            square.Piece = piece;
            square.Board = this;

            if (piece != null)
            {
                piece.CurrentSquare = square;
            }
        }

        private static IntPair ToIndecies(SquareIdentifier squareIdentifier)
        {
            int fileIndex;
            switch (squareIdentifier.File)
            {
                case 'a':
                    fileIndex = 0;
                    break;

                case 'b':
                    fileIndex = 1;
                    break;

                case 'c':
                    fileIndex = 2;
                    break;

                case 'd':
                    fileIndex = 3;
                    break;

                case 'e':
                    fileIndex = 4;
                    break;

                case 'f':
                    fileIndex = 5;
                    break;

                case 'g':
                    fileIndex = 6;
                    break;

                case 'h':
                    fileIndex = 7;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("squareIdentifier", "Invaid label.");
            }

            var rankIndex = Convert.ToInt32(squareIdentifier.Rank.ToString()) - 1;

            var indices = new IntPair(fileIndex, rankIndex);
            return indices;
        }


        private class IntPair
        {
            public IntPair(int item1, int item2)
            {
                Item1 = item1;
                Item2 = item2;
            }

            public int Item1 { get; private set; }
            public int Item2 { get; private set; }
        }
    }
}
