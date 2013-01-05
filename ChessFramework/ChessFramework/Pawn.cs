using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class Pawn : Piece
    {
        public override IEnumerable<SquareIdentifier> GetPossibleMoves()
        {
            return GetPossibleMovesBeforeCheck()
                .ToList()
                .Where(square => IsKingInCheckAfterMove(square) == false);
        }

        private IEnumerable<SquareIdentifier> GetPossibleMovesBeforeCheck()
        {
            var oneForwardSquare = GetMoveOneForwardSquare(CurrentSquare);
            if (oneForwardSquare != null)
            {
                yield return oneForwardSquare.Identifier;
            }

            var twoForwardSquare = GetMoveTwoForwardSquare();
            if (twoForwardSquare != null)
            {
                yield return twoForwardSquare.Identifier;
            }

            foreach (var threatenedSquare in GetThreatenedSquaresWithCapture())
            {
                yield return threatenedSquare.Identifier;
            }
        }

        internal override IEnumerable<Square> GetThreatenedSquares()
        {
            var captureRightPosition = GetCaptureRightSquare();
            if (captureRightPosition != null)
            {
                yield return captureRightPosition;
            }

            var captureLeftPosition = GetCaptureLeftSquare();
            if (captureLeftPosition != null)
            {
                yield return captureLeftPosition;
            }
        }

        private IEnumerable<Square> GetThreatenedSquaresWithCapture()
        {
            return GetThreatenedSquares()
                .Where(square => square != null 
                    && square.Piece != null 
                    && square.Piece.Color != Color);
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

        private Square GetMoveTwoForwardSquare()
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

            return oneForwardSquare != null 
                ? oneForwardSquare.SquareToTheRight 
                : null;
        }

        private Square GetCaptureLeftSquare()
        {
            var oneForwardSquare = Color == Army.White
                ? CurrentSquare.SquareAbove
                : CurrentSquare.SquareBelow;

            return oneForwardSquare != null 
                ? oneForwardSquare.SquareToTheLeft 
                : null;
        }
    }
}
