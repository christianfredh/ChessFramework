using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{ 
    public class Rook : Piece
    {
        public override IEnumerable<SquareIdentifier> GetPossibleMoves()
        {
            return GetThreatenedSquares()
                .Where(square => IsKingInCheckAfterMove(square.Identifier) == false)
                .Select(square => square.Identifier);
        }

        internal override IEnumerable<Square> GetThreatenedSquares()
        {
            return CurrentSquare.Board.Squares
                         .Where(s => Equals(s, CurrentSquare) == false)
                         .Where(IsInReach);
        }

        private bool IsInReach(Square square)
        {
            if (square.IsOccupied() &&
                square.Piece.Color == Color)
            {
                return false;
            }
            return IsFreeBetween(square);
        }

        private bool IsFreeBetween(Square square)
        {
            if (CurrentSquare.Identifier.Rank == square.Identifier.Rank)
            {
                var oneCloserSquare = square.Identifier.File < CurrentSquare.Identifier.File
                    ? square.SquareToTheRight
                    : square.SquareToTheLeft;

                return oneCloserSquare.Equals(CurrentSquare) ||
                    (oneCloserSquare.IsFree() && IsFreeBetween(oneCloserSquare));
            }

            if (CurrentSquare.Identifier.File == square.Identifier.File)
            {
                var oneCloserSquare = square.Identifier.Rank < CurrentSquare.Identifier.Rank 
                    ? square.SquareAbove 
                    : square.SquareBelow;

                return oneCloserSquare.Equals(CurrentSquare) || 
                    (oneCloserSquare.IsFree() && IsFreeBetween(oneCloserSquare));
            }

            return false;
        }
    }
}
