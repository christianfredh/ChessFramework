using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class Pawn : Piece
    {
        public override IEnumerable<SquareIdentifier> GetValidMoves()
        {
            var moveOneForwardPosition = GetMoveOneForwardSquare(CurrentSquare);
            if (moveOneForwardPosition != null)
            {
                yield return moveOneForwardPosition.Identifier;
            }

            var moveTwoForwardPosition = GetMoveTwoForwardPosition();
            if (moveTwoForwardPosition != null)
            {
                yield return moveTwoForwardPosition.Identifier;
            }

            var captureRightPosition = GetCaptureRightSquare();
            if (captureRightPosition != null)
            {
                yield return captureRightPosition.Identifier;
            }

            var captureLeftPosition = GetCaptureLeftSquare();
            if (captureLeftPosition != null)
            {
                yield return captureLeftPosition.Identifier;
            }
        }

        private bool IsStartingSquare()
        {
            switch (Color)
            {
                case Army.White:
                    return CurrentSquare.Identifier.Rank == '2';
                case Army.Black:
                    return CurrentSquare.Identifier.Rank == '7';
                default:
                    return false;
            }
        }

        private Square GetMoveOneForwardSquare(Square from)
        {
            var newSquare = Color == Army.White
                ? from.SquareAbove
                : from.SquareBelow;

            return newSquare != null && newSquare.IsFree()
                ? newSquare
                : null;
        }

        private Square GetMoveTwoForwardPosition()
        {
            if (IsStartingSquare() == false)
            {
                return null;
            }

            var moveOneForwardSquare = GetMoveOneForwardSquare(CurrentSquare);
            return moveOneForwardSquare != null
                ? GetMoveOneForwardSquare(moveOneForwardSquare)
                : null;
        }

        private Square GetCaptureRightSquare()
        {
            var oneForwardSquare = Color == Army.White 
                ? CurrentSquare.SquareAbove 
                : CurrentSquare.SquareBelow;

            if (oneForwardSquare != null)
            {
                var captureSquare = oneForwardSquare.SquareToTheRight;
                if (captureSquare != null)
                {
                    var piece = captureSquare.Piece;
                    if (piece != null && piece.Color != Color)
                    {
                        return captureSquare;
                    }
                }
            }

            return null;
        }

        private Square GetCaptureLeftSquare()
        {
            var oneForwardSquare = Color == Army.White
                ? CurrentSquare.SquareAbove
                : CurrentSquare.SquareBelow;

            if (oneForwardSquare != null)
            {
                var captureSquare = oneForwardSquare.SquareToTheLeft;
                if (captureSquare != null)
                {
                    var piece = captureSquare.Piece;
                    if (piece != null && piece.Color != Color)
                    {
                        return captureSquare;
                    }
                }
            }

            return null;
        }
    }
}
