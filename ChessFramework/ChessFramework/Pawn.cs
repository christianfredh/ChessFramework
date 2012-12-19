using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class Pawn : Piece
    {
        public override IEnumerable<Position> GetValidMoves()
        {
            var moveOneForwardPosition = GetMoveOneForwardPosition(CurrentSquare.Position);
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

        public override void Move(Position to)
        {
            if (GetValidMoves().Contains(to) == false)
            {
                throw new InvalidMoveException(CurrentSquare.Position, to, "Invalid move.");
            }

            CurrentSquare.Piece = null;
            CurrentSquare.Board[to].Piece = this;
            CurrentSquare.Board[to].Piece.CurrentSquare = CurrentSquare.Board[to];
        }

        private bool IsStartingPosition()
        {
            switch (Color)
            {
                case Army.White:
                    return CurrentSquare.Position.VerticalPosition == '2';
                case Army.Black:
                    return CurrentSquare.Position.VerticalPosition == '7';
                default:
                    return false;
            }
        }

        private Position? GetMoveOneForwardPosition(Position from)
        {
            var newPosition = Color == Army.White
                ? from.PositionAbove
                : from.PositionBelow;

            return newPosition != null && CurrentSquare.Board.IsFree(newPosition.Value)
                ? newPosition
                : null;
        }

        private Position? GetMoveTwoForwardPosition()
        {
            if (IsStartingPosition() == false)
            {
                return null;
            }

            var moveOneForwardPosition = GetMoveOneForwardPosition(CurrentSquare.Position);
            return moveOneForwardPosition != null
                ? GetMoveOneForwardPosition(moveOneForwardPosition.Value)
                : null;
        }

        private Position? GetCaptureRightPosition()
        {
            var positionOneForward = Color == Army.White 
                ? CurrentSquare.Position.PositionAbove 
                : CurrentSquare.Position.PositionBelow;

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

        private Position? GetCaptureLeftPosition()
        {
            var positionOneForward = Color == Army.White
                ? CurrentSquare.Position.PositionAbove
                : CurrentSquare.Position.PositionBelow;

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
