using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class Bishop : Piece
    {
        private readonly Func<Square, Square> _squareUpRight = square => square.SquareDiagonallyUpAndRight;
        private readonly Func<Square, Square> _squareUpLeft = square => square.SquareDiagonallyUpAndLeft;
        private readonly Func<Square, Square> _squareDownRight = square => square.SquareDiagonallyDownAndRight;
        private readonly Func<Square, Square> _squareDownLeft = square => square.SquareDiagonallyDownAndLeft;

        public override IEnumerable<SquareIdentifier> GetValidMoves()
        {
            var validSquares = new List<Square>();
            validSquares.AddRange(GetSquaresDiagonally(CurrentSquare, _squareUpRight));
            validSquares.AddRange(GetSquaresDiagonally(CurrentSquare, _squareUpLeft));
            validSquares.AddRange(GetSquaresDiagonally(CurrentSquare, _squareDownRight));
            validSquares.AddRange(GetSquaresDiagonally(CurrentSquare, _squareDownLeft));

            return validSquares.Select(square => square.Identifier);
        }

        private IEnumerable<Square> GetSquaresDiagonally(Square square, Func<Square, Square> directionFunc)
        {
            var diagonalSquare = directionFunc(square);
            var squares = new List<Square>();
            if (CanMoveTo(diagonalSquare))
            {
                squares.Add(diagonalSquare);
                squares.AddRange(GetSquaresDiagonally(diagonalSquare, directionFunc));
            }

            return squares;
        }

        private bool CanMoveTo(Square square)
        {
            return square != null && (square.IsFree() || square.Piece.Color != Color);
        }
    }
}
