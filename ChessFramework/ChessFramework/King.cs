using System;
using System.Collections.Generic;

namespace ChessFramework
{
    public class King : Piece
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

                    // TODO: Cannot move if the king is in check at new location....
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
            yield return () => CurrentSquare.SquareAbove;
            yield return () => CurrentSquare.SquareBelow;
            yield return () => CurrentSquare.SquareToTheRight;
            yield return () => CurrentSquare.SquareToTheLeft;

            yield return () => CurrentSquare.SquareAbove.SquareToTheLeft;
            yield return () => CurrentSquare.SquareAbove.SquareToTheRight;
            yield return () => CurrentSquare.SquareBelow.SquareToTheLeft;
            yield return () => CurrentSquare.SquareBelow.SquareToTheRight;
        }
    }
}
