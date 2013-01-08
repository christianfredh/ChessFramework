using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ChessFramework
{
    [DebuggerDisplay("{Color} {GetType().Name,nq}")]
    public abstract class Piece
    {
        public Army Color { get; set; }
        public Square CurrentSquare { get; set; }

        public virtual void Move(SquareIdentifier to)
        {
            if (GetPossibleMoves().Contains(to) == false)
            {
                throw new InvalidMoveException(CurrentSquare.Identifier, to, string.Format("{0} to {1} is an invalid move.", CurrentSquare.Identifier, to));
            }

            var from = CurrentSquare.Identifier;
            var movedPiece = this;
            var capturedPiece = CurrentSquare.Board[to].Piece;

            CurrentSquare.Piece = null;
            CurrentSquare.Board[to].Piece = this;
            CurrentSquare.Board[to].Piece.CurrentSquare = CurrentSquare.Board[to];

            CurrentSquare.Board.History.Moves.Add(
                new Move
                {
                    From = from,
                    To = to,
                    MovedPiece = movedPiece,
                    CapturedPiece = capturedPiece
                });
        }

        public abstract IEnumerable<SquareIdentifier> GetPossibleMoves();
        internal abstract IEnumerable<Square> GetThreatenedSquares();

        protected bool IsKingInCheckAfterMove(SquareIdentifier squareIdentifier)
        {
            var board = CurrentSquare.Board;


            var squareBefore = CurrentSquare;
            var squareAfter = board[squareIdentifier];
            var pieceAtNewSquare = squareAfter.Piece;

            CurrentSquare.Piece = null;
            CurrentSquare = squareAfter;
            squareAfter.Piece = this;

            var isInCheckAfterMove = board.IsInCheck(Color);

            squareBefore.Piece = this;
            squareAfter.Piece = pieceAtNewSquare;
            CurrentSquare = squareBefore;

            return isInCheckAfterMove;
        }
    }
}
