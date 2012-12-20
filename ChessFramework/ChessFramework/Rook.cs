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
            if (CurrentSquare.Position.Rank == position.Rank)
            {
                var oneCloserPosition = position.File < CurrentSquare.Position.File
                    ? position.PositionToTheRight.Value
                    : position.PositionToTheLeft.Value;

                return oneCloserPosition.Equals(CurrentSquare.Position) ||
                    (CurrentSquare.Board.IsFree(oneCloserPosition) && IsFreeBetween(oneCloserPosition));
            }

            if (CurrentSquare.Position.File == position.File)
            {
                var oneCloserPosition = position.Rank < CurrentSquare.Position.Rank 
                    ? position.PositionAbove.Value 
                    : position.PositionBelow.Value;

                return oneCloserPosition.Equals(CurrentSquare.Position) || 
                    (CurrentSquare.Board.IsFree(oneCloserPosition) && IsFreeBetween(oneCloserPosition));
            }

            return false;
        }
    }
}
