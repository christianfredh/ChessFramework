using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class Knight : Piece
    {
        public override IEnumerable<SquareIdentifier> GetPossibleMoves()
        {
            return GetThreatenedSquares()
                .Where(square => IsKingInCheckAfterMove(square.Identifier) == false)
                .Select(square => square.Identifier);
        }

        internal override IEnumerable<Square> GetThreatenedSquares()
        {
            var threatenedSquares = new List<Square>();
            foreach (var func in GetBaseMovesFuncs())
            {
                try
                {
                    var validSquare = func();
                    if (validSquare.IsFree() || validSquare.Piece.Color != Color)
                    {
                        threatenedSquares.Add(validSquare);
                    }
                }
                catch (NullReferenceException)
                {
                    // Outside the board
                }
            }

            return threatenedSquares;
        }

        private IEnumerable<Func<Square>> GetBaseMovesFuncs()
        {
            yield return () => CurrentSquare.SquareAbove.SquareDiagonallyUpAndLeft;
            yield return () => CurrentSquare.SquareAbove.SquareDiagonallyUpAndRight;

            yield return () => CurrentSquare.SquareBelow.SquareDiagonallyDownAndLeft;
            yield return () => CurrentSquare.SquareBelow.SquareDiagonallyDownAndRight;

            yield return () => CurrentSquare.SquareToTheRight.SquareDiagonallyUpAndRight;
            yield return () => CurrentSquare.SquareToTheRight.SquareDiagonallyDownAndRight;

            yield return () => CurrentSquare.SquareToTheLeft.SquareDiagonallyUpAndLeft;
            yield return () => CurrentSquare.SquareToTheLeft.SquareDiagonallyDownAndLeft;
        }
    }
}
