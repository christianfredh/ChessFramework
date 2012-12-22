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
            yield return () => CurrentSquare.SquareAbove.SquareAbove.SquareToTheLeft;
            yield return () => CurrentSquare.SquareAbove.SquareAbove.SquareToTheRight;

            yield return () => CurrentSquare.SquareBelow.SquareBelow.SquareToTheLeft;
            yield return () => CurrentSquare.SquareBelow.SquareBelow.SquareToTheRight;

            yield return () => CurrentSquare.SquareToTheLeft.SquareToTheLeft.SquareBelow;
            yield return () => CurrentSquare.SquareToTheLeft.SquareToTheLeft.SquareAbove;

            yield return () => CurrentSquare.SquareToTheRight.SquareToTheRight.SquareBelow;
            yield return () => CurrentSquare.SquareToTheRight.SquareToTheRight.SquareAbove;
        }
    }
}
