using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class Pawn : Piece
    {
        public override IEnumerable<SquareIdentifier> GetValidMoves()
        {
            var moveOneForwardPosition = GetMoveOneForwardPosition(CurrentSquare.SquareIdentifier);
            if (moveOneForwardPosition != null)
            {
                yield return moveOneForwardPosition.Value;
            }

            var moveTwoForwardPosition = GetMoveTwoForwardPosition();
            if (moveTwoForwardPosition != null)
            {
                yield return moveTwoForwardPosition.Value;
            }

            var captureRightPosition = GetCaptureRightPosition();
            if (captureRightPosition != null)
            {
                yield return captureRightPosition.Value;
            }

            var captureLeftPosition = GetCaptureLeftPosition();
            if (captureLeftPosition != null)
            {
                yield return captureLeftPosition.Value;
            }
        }

        private bool IsStartingPosition()
        {
            switch (Color)
            {
                case Army.White:
                    return CurrentSquare.SquareIdentifier.Rank == '2';
                case Army.Black:
                    return CurrentSquare.SquareIdentifier.Rank == '7';
                default:
                    return false;
            }
        }

        private SquareIdentifier? GetMoveOneForwardPosition(SquareIdentifier from)
        {
            var newPosition = Color == Army.White
                ? from.PositionAbove
                : from.PositionBelow;

            return newPosition != null && CurrentSquare.Board.IsFree(newPosition.Value)
                ? newPosition
                : null;
        }

        private SquareIdentifier? GetMoveTwoForwardPosition()
        {
            if (IsStartingPosition() == false)
            {
                return null;
            }

            var moveOneForwardPosition = GetMoveOneForwardPosition(CurrentSquare.SquareIdentifier);
            return moveOneForwardPosition != null
                ? GetMoveOneForwardPosition(moveOneForwardPosition.Value)
                : null;
        }

        private SquareIdentifier? GetCaptureRightPosition()
        {
            var positionOneForward = Color == Army.White 
                ? CurrentSquare.SquareIdentifier.PositionAbove 
                : CurrentSquare.SquareIdentifier.PositionBelow;

            if (positionOneForward != null)
            {
                var capturePosition = positionOneForward.Value.PositionToTheRight;
                if (capturePosition != null)
                {
                    var piece = CurrentSquare.Board[capturePosition.Value].Piece;
                    if (piece != null && piece.Color != Color)
                    {
                        return capturePosition;
                    }
                }
            }

            return null;
        }

        private SquareIdentifier? GetCaptureLeftPosition()
        {
            var positionOneForward = Color == Army.White
                ? CurrentSquare.SquareIdentifier.PositionAbove
                : CurrentSquare.SquareIdentifier.PositionBelow;

            if (positionOneForward != null)
            {
                var capturePosition = positionOneForward.Value.PositionToTheLeft;
                if (capturePosition != null)
                {
                    var piece = CurrentSquare.Board[capturePosition.Value].Piece;
                    if (piece != null && piece.Color != Color)
                    {
                        return capturePosition;
                    }
                }
            }

            return null;
        }
    }
}
