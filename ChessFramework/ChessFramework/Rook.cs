using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class Rook : Piece
    {
        public override IEnumerable<Position> GetValidMoves()
        {
            return CurrentSquare.Board.AllPositions
                         .Where(p => Equals(p, CurrentSquare.Position) == false)
                         .Where(IsInReach);
        }

        private bool IsInReach(Position position)
        {
            if (CurrentSquare.Board[position].IsOccupied() &&
                CurrentSquare.Board[position].Piece.Color == Color)
            {
                return false;
            }
            return IsFreeBetween(position);
        }

        private bool IsFreeBetween(Position position)
        {
            if (CurrentSquare.Position.VerticalPosition == position.VerticalPosition)
            {
                var oneCloserPosition = position.HorizontalPosition < CurrentSquare.Position.HorizontalPosition
                    ? position.PositionToTheRight.Value
                    : position.PositionToTheLeft.Value;

                return oneCloserPosition.Equals(CurrentSquare.Position) ||
                    (CurrentSquare.Board.IsFree(oneCloserPosition) && IsFreeBetween(oneCloserPosition));
            }

            if (CurrentSquare.Position.HorizontalPosition == position.HorizontalPosition)
            {
                var oneCloserPosition = position.VerticalPosition < CurrentSquare.Position.VerticalPosition 
                    ? position.PositionAbove.Value 
                    : position.PositionBelow.Value;

                return oneCloserPosition.Equals(CurrentSquare.Position) || 
                    (CurrentSquare.Board.IsFree(oneCloserPosition) && IsFreeBetween(oneCloserPosition));
            }

            return false;
        }
    }
}
