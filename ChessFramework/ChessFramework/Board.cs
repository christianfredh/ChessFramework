using System;

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

            InitializePosition("a", "1", SquareColor.Black, new Rook { Color = Army.White });
            InitializePosition("b", "1", SquareColor.White, new Knight { Color = Army.White });
            InitializePosition("c", "1", SquareColor.Black, new Bishop { Color = Army.White });
            InitializePosition("d", "1", SquareColor.White, new Queen { Color = Army.White });
            InitializePosition("e", "1", SquareColor.Black, new King { Color = Army.White });
            InitializePosition("f", "1", SquareColor.White, new Bishop { Color = Army.White });
            InitializePosition("g", "1", SquareColor.Black, new Knight { Color = Army.White });
            InitializePosition("h", "1", SquareColor.White, new Rook { Color = Army.White });

            InitializePosition("a", "2", SquareColor.White, new Pawn { Color = Army.White });
            InitializePosition("b", "2", SquareColor.Black, new Pawn { Color = Army.White });
            InitializePosition("c", "2", SquareColor.White, new Pawn { Color = Army.White });
            InitializePosition("d", "2", SquareColor.Black, new Pawn { Color = Army.White });
            InitializePosition("e", "2", SquareColor.White, new Pawn { Color = Army.White });
            InitializePosition("f", "2", SquareColor.Black, new Pawn { Color = Army.White });
            InitializePosition("g", "2", SquareColor.White, new Pawn { Color = Army.White });
            InitializePosition("h", "2", SquareColor.Black, new Pawn { Color = Army.White });

            InitializePosition("a", "3", SquareColor.Black, null);
            InitializePosition("b", "3", SquareColor.White, null);
            InitializePosition("c", "3", SquareColor.Black, null);
            InitializePosition("d", "3", SquareColor.White, null);
            InitializePosition("e", "3", SquareColor.Black, null);
            InitializePosition("f", "3", SquareColor.White, null);
            InitializePosition("g", "3", SquareColor.Black, null);
            InitializePosition("h", "3", SquareColor.White, null);

            InitializePosition("a", "4", SquareColor.White, null);
            InitializePosition("b", "4", SquareColor.Black, null);
            InitializePosition("c", "4", SquareColor.White, null);
            InitializePosition("d", "4", SquareColor.Black, null);
            InitializePosition("e", "4", SquareColor.White, null);
            InitializePosition("f", "4", SquareColor.Black, null);
            InitializePosition("g", "4", SquareColor.White, null);
            InitializePosition("h", "4", SquareColor.Black, null);

            InitializePosition("a", "5", SquareColor.Black, null);
            InitializePosition("b", "5", SquareColor.White, null);
            InitializePosition("c", "5", SquareColor.Black, null);
            InitializePosition("d", "5", SquareColor.White, null);
            InitializePosition("e", "5", SquareColor.Black, null);
            InitializePosition("f", "5", SquareColor.White, null);
            InitializePosition("g", "5", SquareColor.Black, null);
            InitializePosition("h", "5", SquareColor.White, null);

            InitializePosition("a", "6", SquareColor.White, null);
            InitializePosition("b", "6", SquareColor.Black, null);
            InitializePosition("c", "6", SquareColor.White, null);
            InitializePosition("d", "6", SquareColor.Black, null);
            InitializePosition("e", "6", SquareColor.White, null);
            InitializePosition("f", "6", SquareColor.Black, null);
            InitializePosition("g", "6", SquareColor.White, null);
            InitializePosition("h", "6", SquareColor.Black, null);

            InitializePosition("a", "7", SquareColor.Black, new Pawn { Color = Army.Black });
            InitializePosition("b", "7", SquareColor.White, new Pawn { Color = Army.Black });
            InitializePosition("c", "7", SquareColor.Black, new Pawn { Color = Army.Black });
            InitializePosition("d", "7", SquareColor.White, new Pawn { Color = Army.Black });
            InitializePosition("e", "7", SquareColor.Black, new Pawn { Color = Army.Black });
            InitializePosition("f", "7", SquareColor.White, new Pawn { Color = Army.Black });
            InitializePosition("g", "7", SquareColor.Black, new Pawn { Color = Army.Black });
            InitializePosition("h", "7", SquareColor.White, new Pawn { Color = Army.Black });

            InitializePosition("a", "8", SquareColor.White, new Rook { Color = Army.Black });
            InitializePosition("b", "8", SquareColor.Black, new Knight { Color = Army.Black });
            InitializePosition("c", "8", SquareColor.White, new Bishop { Color = Army.Black });
            InitializePosition("d", "8", SquareColor.Black, new Queen { Color = Army.Black });
            InitializePosition("e", "8", SquareColor.White, new King { Color = Army.Black });
            InitializePosition("f", "8", SquareColor.Black, new Bishop { Color = Army.Black });
            InitializePosition("g", "8", SquareColor.White, new Knight { Color = Army.Black });
            InitializePosition("h", "8", SquareColor.Black, new Rook { Color = Army.Black });
        }

        public Square this[Position position]
        {
            get
            {
                var indicies = ToIndecies(position);
                return _squares[indicies.Item1, indicies.Item2];
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

        private void InitializePosition(string horizontalPosition, string verticalPosition, SquareColor squareColor, Piece piece)
        {
            var position = new Position { HorizontalPosition = horizontalPosition, VerticalPosition = verticalPosition };
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
                case "a":
                    horizontalIndex = 0;
                    break;

                case "b":
                    horizontalIndex = 1;
                    break;

                case "c":
                    horizontalIndex = 2;
                    break;

                case "d":
                    horizontalIndex = 3;
                    break;

                case "e":
                    horizontalIndex = 4;
                    break;

                case "f":
                    horizontalIndex = 5;
                    break;

                case "g":
                    horizontalIndex = 6;
                    break;

                case "h":
                    horizontalIndex = 7;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("position", "Invaid positionText.");
            }

            var verticalIndex = Convert.ToInt32(position.VerticalPosition) - 1;

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
