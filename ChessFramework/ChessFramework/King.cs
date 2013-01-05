using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class King : Piece
    {
        public override IEnumerable<SquareIdentifier> GetPossibleMoves()
        {
            return GetThreatenedSquares()
                .Where(square => IsKingInCheckAfterMove(square.Identifier) == false)
                .Select(square => square.Identifier);
        }

        internal override IEnumerable<Square> GetThreatenedSquares()
        {
            return GetBaseMoves()
                .Where(move => move != null && (move.IsFree() || move.Piece.Color != Color));
        }

        private IEnumerable<Square> GetBaseMoves()
        {
            yield return CurrentSquare.SquareAbove;
            yield return CurrentSquare.SquareBelow;
            yield return CurrentSquare.SquareToTheRight;
            yield return CurrentSquare.SquareToTheLeft;

            yield return CurrentSquare.SquareDiagonallyUpAndRight;
            yield return CurrentSquare.SquareDiagonallyUpAndLeft;
            yield return CurrentSquare.SquareDiagonallyDownAndRight;
            yield return CurrentSquare.SquareDiagonallyDownAndLeft;
        }
    }
}
