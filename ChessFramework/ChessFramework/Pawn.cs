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

        public override void Move(SquareIdentifier to)
        {
            if (GetPossibleMoves().Contains(to) == false)
            {
                throw new IllegalMoveException(CurrentSquare.Identifier, to, string.Format("{0} to {1} is an invalid move.", CurrentSquare.Identifier, to));
            }

            var from = CurrentSquare.Identifier;
            var movedPiece = this;
            var capturedPiece = CurrentSquare.Board[to].Piece;

            CurrentSquare.Piece = null;
            var toSquare = CurrentSquare.Board[to];

            if (IsEnPassantMove(toSquare))
            {
                if (Color == Army.White)
                {
                    capturedPiece = toSquare.SquareBelow.Piece;
                    toSquare.SquareBelow.Piece = null;
                }
                else
                {
                    capturedPiece = toSquare.SquareAbove.Piece;
                    toSquare.SquareAbove.Piece = null;
                }
            }

            toSquare.Piece = this;
            toSquare.Piece.CurrentSquare = toSquare;

            CurrentSquare.Board.History.Moves.Add(
                new Move
                {
                    From = from,
                    To = to,
                    MovedPiece = movedPiece,
                    CapturedPiece = capturedPiece
                });

            if (IsPromotionSquare(toSquare))
            {
                Piece promotedPiece;

                switch (CurrentSquare.Board.PromotionChoice())
                {
                    case PromotionChoice.Rook:
                        promotedPiece = new Rook();
                        break;
                    case PromotionChoice.Bishop:
                        promotedPiece = new Bishop();
                        break;
                    case PromotionChoice.Knight:
                        promotedPiece = new Knight();
                        break;
                    default:
                        promotedPiece = new Queen();
                        break;
                }

                promotedPiece.CurrentSquare = toSquare;
                toSquare.Piece = promotedPiece;
            }
        }

        private bool IsPromotionSquare(Square square)
        {
            return Color == Army.White
                ? square.Identifier.Rank == '8'
                : square.Identifier.Rank == '1';
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

                .Where(square => square != null)
                .Where(square =>
                    (square.Piece != null && square.Piece.Color != Color) ||
                    (IsEnPassantMove(square)));
        }

        private bool IsEnPassantMove(Square move)
        {
            if (move.Identifier.Rank == '6')
            {
                var lastMove = move.Board.History.Moves.LastOrDefault();
                if (lastMove != null)
                {
                    if (lastMove.MovedPiece is Pawn && lastMove.From.File == move.Identifier.File && lastMove.To.File == move.Identifier.File)
                    {
                        if (Color == Army.White && lastMove.From.Rank == '7' && lastMove.To.Rank == '5')
                        {
                            return true;
                        }

                        if (lastMove.From.Rank == '2' && lastMove.To.Rank == '4')
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
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
