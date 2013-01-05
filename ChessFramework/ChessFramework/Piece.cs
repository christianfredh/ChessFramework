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

        public void Move(SquareIdentifier to)
        {
            if (GetPossibleMoves().Contains(to) == false)
            {
                throw new InvalidMoveException(CurrentSquare.Identifier, to, string.Format("{0} to {1} is an invalid move.", CurrentSquare.Identifier, to));
            }

            CurrentSquare.Piece = null;
            CurrentSquare.Board[to].Piece = this;
            CurrentSquare.Board[to].Piece.CurrentSquare = CurrentSquare.Board[to];
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
