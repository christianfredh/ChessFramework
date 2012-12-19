using System;
using System.Collections.Generic;

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

            InitializePosition("a1", SquareColor.Black, new Rook { Color = Army.White });
            InitializePosition("b1", SquareColor.White, new Knight { Color = Army.White });
            InitializePosition("c1", SquareColor.Black, new Bishop { Color = Army.White });
            InitializePosition("d1", SquareColor.White, new Queen { Color = Army.White });
            InitializePosition("e1", SquareColor.Black, new King { Color = Army.White });
            InitializePosition("f1", SquareColor.White, new Bishop { Color = Army.White });
            InitializePosition("g1", SquareColor.Black, new Knight { Color = Army.White });
            InitializePosition("h1", SquareColor.White, new Rook { Color = Army.White });

            InitializePosition("a2", SquareColor.White, new Pawn { Color = Army.White });
            InitializePosition("b2", SquareColor.Black, new Pawn { Color = Army.White });
            InitializePosition("c2", SquareColor.White, new Pawn { Color = Army.White });
            InitializePosition("d2", SquareColor.Black, new Pawn { Color = Army.White });
            InitializePosition("e2", SquareColor.White, new Pawn { Color = Army.White });
            InitializePosition("f2", SquareColor.Black, new Pawn { Color = Army.White });
            InitializePosition("g2", SquareColor.White, new Pawn { Color = Army.White });
            InitializePosition("h2", SquareColor.Black, new Pawn { Color = Army.White });

            InitializePosition("a3", SquareColor.Black, null);
            InitializePosition("b3", SquareColor.White, null);
            InitializePosition("c3", SquareColor.Black, null);
            InitializePosition("d3", SquareColor.White, null);
            InitializePosition("e3", SquareColor.Black, null);
            InitializePosition("f3", SquareColor.White, null);
            InitializePosition("g3", SquareColor.Black, null);
            InitializePosition("h3", SquareColor.White, null);

            InitializePosition("a4", SquareColor.White, null);
            InitializePosition("b4", SquareColor.Black, null);
            InitializePosition("c4", SquareColor.White, null);
            InitializePosition("d4", SquareColor.Black, null);
            InitializePosition("e4", SquareColor.White, null);
            InitializePosition("f4", SquareColor.Black, null);
            InitializePosition("g4", SquareColor.White, null);
            InitializePosition("h4", SquareColor.Black, null);

            InitializePosition("a5", SquareColor.Black, null);
            InitializePosition("b5", SquareColor.White, null);
            InitializePosition("c5", SquareColor.Black, null);
            InitializePosition("d5", SquareColor.White, null);
            InitializePosition("e5", SquareColor.Black, null);
            InitializePosition("f5", SquareColor.White, null);
            InitializePosition("g5", SquareColor.Black, null);
            InitializePosition("h5", SquareColor.White, null);

            InitializePosition("a6", SquareColor.White, null);
            InitializePosition("b6", SquareColor.Black, null);
            InitializePosition("c6", SquareColor.White, null);
            InitializePosition("d6", SquareColor.Black, null);
            InitializePosition("e6", SquareColor.White, null);
            InitializePosition("f6", SquareColor.Black, null);
            InitializePosition("g6", SquareColor.White, null);
            InitializePosition("h6", SquareColor.Black, null);

            InitializePosition("a7", SquareColor.Black, new Pawn { Color = Army.Black });
            InitializePosition("b7", SquareColor.White, new Pawn { Color = Army.Black });
            InitializePosition("c7", SquareColor.Black, new Pawn { Color = Army.Black });
            InitializePosition("d7", SquareColor.White, new Pawn { Color = Army.Black });
            InitializePosition("e7", SquareColor.Black, new Pawn { Color = Army.Black });
            InitializePosition("f7", SquareColor.White, new Pawn { Color = Army.Black });
            InitializePosition("g7", SquareColor.Black, new Pawn { Color = Army.Black });
            InitializePosition("h7", SquareColor.White, new Pawn { Color = Army.Black });

            InitializePosition("a8", SquareColor.White, new Rook { Color = Army.Black });
            InitializePosition("b8", SquareColor.Black, new Knight { Color = Army.Black });
            InitializePosition("c8", SquareColor.White, new Bishop { Color = Army.Black });
            InitializePosition("d8", SquareColor.Black, new Queen { Color = Army.Black });
            InitializePosition("e8", SquareColor.White, new King { Color = Army.Black });
            InitializePosition("f8", SquareColor.Black, new Bishop { Color = Army.Black });
            InitializePosition("g8", SquareColor.White, new Knight { Color = Army.Black });
            InitializePosition("h8", SquareColor.Black, new Rook { Color = Army.Black });
        }

        public Square this[Position position]
        {
            get
            {
                var indicies = ToIndecies(position);
                return _squares[indicies.Item1, indicies.Item2];
            }
        }

        public IEnumerable<Position> AllPositions
        {
            get
            {
                for (var horizontalPosition = 'a'; horizontalPosition < 'h'; horizontalPosition++)
                {
                    for (var verticalPosition = '1'; verticalPosition < '8'; verticalPosition++)
                    {
                        yield return new Position(horizontalPosition, verticalPosition);
                    }
                }
            }
        }

        public bool IsOccupied(Position position)
        {
            return this[position].IsOccupied();
        }

        public bool IsFree(Position position)
        {
            return this[position].IsFree();
        }

        private void InitializePosition(string positionText, SquareColor squareColor, Piece piece)
        {
            var position = new Position(positionText);
            var square = this[position];
            square.Position = position;
            square.Color = squareColor;
            square.Piece = piece;
            square.Board = this;

            if (piece != null)
            {
                piece.CurrentSquare = square;
            }
        }

        private static IntPair ToIndecies(Position position)
        {
            int horizontalIndex;
            switch (position.HorizontalPosition)
            {
                case 'a':
                    horizontalIndex = 0;
                    break;

                case 'b':
                    horizontalIndex = 1;
                    break;

                case 'c':
                    horizontalIndex = 2;
                    break;

                case 'd':
                    horizontalIndex = 3;
                    break;

                case 'e':
                    horizontalIndex = 4;
                    break;

                case 'f':
                    horizontalIndex = 5;
                    break;

                case 'g':
                    horizontalIndex = 6;
                    break;

                case 'h':
                    horizontalIndex = 7;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("position", "Invaid positionText.");
            }

            var verticalIndex = Convert.ToInt32(position.VerticalPosition.ToString()) - 1;

            var indices = new IntPair(horizontalIndex, verticalIndex);
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
