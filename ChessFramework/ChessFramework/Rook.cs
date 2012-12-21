using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class Rook : Piece
    {
        public override IEnumerable<SquareIdentifier> GetValidMoves()
        {
            return CurrentSquare.Board.AllPositions
                         .Where(p => Equals(p, CurrentSquare.SquareIdentifier) == false)
                         .Where(IsInReach);
        }

        private bool IsInReach(SquareIdentifier squareIdentifier)
        {
            if (CurrentSquare.Board[squareIdentifier].IsOccupied() &&
                CurrentSquare.Board[squareIdentifier].Piece.Color == Color)
            {
                return false;
            }
            return IsFreeBetween(squareIdentifier);
        }

        private bool IsFreeBetween(SquareIdentifier squareIdentifier)
        {
            if (CurrentSquare.SquareIdentifier.Rank == squareIdentifier.Rank)
            {
                var oneCloserPosition = squareIdentifier.File < CurrentSquare.SquareIdentifier.File
                    ? squareIdentifier.PositionToTheRight.Value
                    : squareIdentifier.PositionToTheLeft.Value;

                return oneCloserPosition.Equals(CurrentSquare.SquareIdentifier) ||
                    (CurrentSquare.Board.IsFree(oneCloserPosition) && IsFreeBetween(oneCloserPosition));
            }

            if (CurrentSquare.SquareIdentifier.File == squareIdentifier.File)
            {
                var oneCloserPosition = squareIdentifier.Rank < CurrentSquare.SquareIdentifier.Rank 
                    ? squareIdentifier.PositionAbove.Value 
                    : squareIdentifier.PositionBelow.Value;

                return oneCloserPosition.Equals(CurrentSquare.SquareIdentifier) || 
                    (CurrentSquare.Board.IsFree(oneCloserPosition) && IsFreeBetween(oneCloserPosition));
            }

            return false;
        }
    }
}
