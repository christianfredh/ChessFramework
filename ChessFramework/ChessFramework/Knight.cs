using System;
using System.Collections.Generic;

namespace ChessFramework
{
    public class Knight : Piece
    {
        public override IEnumerable<SquareIdentifier> GetValidMoves()
        {
            var validMoves = new List<SquareIdentifier>();
            foreach (var func in GetBaseMovesFuncs())
            {
                try
                {
                    var validSquare = func();
                    if (validSquare.IsFree() || validSquare.Piece.Color != Color)
                    {
                        validMoves.Add(validSquare.Identifier);
                    }

                    // TODO: Cannot move if the king is left in check....
                }
                catch (NullReferenceException)
                {
                    // Outside the board
                }
            }

            return validMoves;
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
