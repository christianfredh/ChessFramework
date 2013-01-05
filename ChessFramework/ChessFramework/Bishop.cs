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

        public override IEnumerable<SquareIdentifier> GetPossibleMoves()
        {
            return GetThreatenedSquares()
                .Where(square => IsKingInCheckAfterMove(square.Identifier) == false)
                .Select(square => square.Identifier);
        }

        internal override IEnumerable<Square> GetThreatenedSquares()
        {
            var squares = new List<Square>();
            squares.AddRange(GetSquaresInDirection(CurrentSquare, _squareUpRight));
            squares.AddRange(GetSquaresInDirection(CurrentSquare, _squareUpLeft));
            squares.AddRange(GetSquaresInDirection(CurrentSquare, _squareDownRight));
            squares.AddRange(GetSquaresInDirection(CurrentSquare, _squareDownLeft));

            return squares;
        }

        private IEnumerable<Square> GetSquaresInDirection(Square square, Func<Square, Square> directionFunc)
        {
            var squareInDirection = directionFunc(square);
            var squares = new List<Square>();
            if (CanMoveTo(squareInDirection))
            {
                squares.Add(squareInDirection);

                if (squareInDirection.IsFree())
                {
                    squares.AddRange(GetSquaresInDirection(squareInDirection, directionFunc));
                }
            }

            return squares;
        }

        private bool CanMoveTo(Square square)
        {
            return square != null && (square.IsFree() || square.Piece.Color != Color);
        }
    }
}
