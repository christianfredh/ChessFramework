using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ChessFramework
{
    public class Pawn : Piece
    {
        public override IEnumerable<Position> GetValidMoves()
        {
            if (CanMoveOneForward())
            {
                yield return GetMoveOneForwardPosition();
            }

            if (CanMoveTwoForward())
            {
                yield return GetMoveTwoForwardPosition();
            }

            if (CanCaptureRight())
            {
                yield return GetCaptureRightPosition();
            }

            if (CanCaptureLeft())
            {
                yield return GetCaptureLeftPosition();
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

        private bool CanMoveOneForward()
        {
            if (Color == Army.White && CurrentSquare.Position.VerticalPosition == '8')
            {
                return false;
            }

            if (Color == Army.Black && CurrentSquare.Position.VerticalPosition == '1')
            {
                return false;
            }

            if (CurrentSquare.Board.IsOccupied(GetMoveOneForwardPosition()))
            {
                return false;
            }

            return true;
        }

        private bool CanMoveTwoForward()
        {
            return IsStartingPosition() &&
                   CanMoveOneForward() && 
                   CurrentSquare.Board.IsFree(GetMoveTwoForwardPosition());
        }

        private Position GetMoveOneForwardPosition()
        {
            return Color == Army.White
                ? GetPositionAbove(CurrentSquare.Position)
                : GetPositionBelow(CurrentSquare.Position);
        }

        private static Position GetPositionBelow(Position position)
        {
            var horizontalPosition = position.HorizontalPosition;
            var verticalPosition = (Convert.ToInt32(position.VerticalPosition.ToString()) - 1).ToString(CultureInfo.InvariantCulture)[0];

            return new Position { HorizontalPosition = horizontalPosition, VerticalPosition = verticalPosition };
        }

        private static Position GetPositionAbove(Position position)
        {
            var horizontalPosition = position.HorizontalPosition;
            var verticalPosition = (Convert.ToInt32(position.VerticalPosition.ToString()) + 1).ToString(CultureInfo.InvariantCulture)[0];

            return new Position { HorizontalPosition = horizontalPosition, VerticalPosition = verticalPosition };
        }

        private Position GetMoveTwoForwardPosition()
        {
            return Color == Army.White
                   ? GetPositionAbove(GetPositionAbove(CurrentSquare.Position))
                   : GetPositionBelow(GetPositionBelow(CurrentSquare.Position));
        }

        private bool CanCaptureRight()
        {
            // ...
            return false;
        }

        private bool CanCaptureLeft()
        {
            // ...
            return false;
        }

        private Position GetCaptureRightPosition()
        {
            // ...
            return new Position();
        }

        private Position GetCaptureLeftPosition()
        {
            // ...
            return new Position();
        }
    }
}
