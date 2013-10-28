using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class King : Piece
    {
        private IEnumerable<Square> _possibleCastelingMoves;
        private bool _hasMoved;

        public override void Move(SquareIdentifier to)
        {
            var castelingMoves = GetCastelingMoves()
                    .Select(s => s.Identifier)
                    .ToList();


            if (castelingMoves.Contains(to))
            {
                var oldFile = 'a';
                var newFile = 'd';
                var rank = '1';

                if (to.File > CurrentSquare.Identifier.File)
                {
                    oldFile = 'h';
                    newFile = 'f';
                }

                if (Color == Army.Black)
                {
                    rank = '8';
                }

                var oldSquareIdentifier = new SquareIdentifier(oldFile, rank);
                var newSquareIdentifier = new SquareIdentifier(newFile, rank);

                var rook = CurrentSquare.Board[oldSquareIdentifier].Piece;

                CurrentSquare.Board[oldSquareIdentifier].Piece = null;
                CurrentSquare.Board[newSquareIdentifier].Piece = rook;
                rook.CurrentSquare = CurrentSquare.Board[newSquareIdentifier];
            }

            try
            {
                base.Move(to);
                _hasMoved = true;
            }
            finally
            {
                _possibleCastelingMoves = null;
            }
        }

        public override IEnumerable<SquareIdentifier> GetPossibleMoves()
        {
            return GetThreatenedSquares()
                .Where(square => IsKingInCheckAfterMove(square.Identifier) == false)
                .Union(GetCastelingMoves())
                .Select(square => square.Identifier);
        }

        internal override IEnumerable<Square> GetThreatenedSquares()
        {
            return GetBaseMoves()
                .Where(move => move != null && (move.IsFree() || move.Piece.Color != Color));
        }

        private IEnumerable<Square> GetBaseMoves()
        {
            yield return CurrentSquare.SquareAbove;
            yield return CurrentSquare.SquareBelow;
            yield return CurrentSquare.SquareToTheRight;
            yield return CurrentSquare.SquareToTheLeft;

            yield return CurrentSquare.SquareDiagonallyUpAndRight;
            yield return CurrentSquare.SquareDiagonallyUpAndLeft;
            yield return CurrentSquare.SquareDiagonallyDownAndRight;
            yield return CurrentSquare.SquareDiagonallyDownAndLeft;
        }

        private IEnumerable<Square> GetCastelingMoves()
        {
            if (_possibleCastelingMoves == null)
            {
                _possibleCastelingMoves = CalculateCastelingMoves().ToList();
            }

            return _possibleCastelingMoves;
        }

        private IEnumerable<Square> CalculateCastelingMoves()
        {
            if (_hasMoved)
            {
                yield break;
            }

            if (IsInCheck())
            {
                yield break;
            }


            var kingsideRook = CurrentSquare.SquareToTheRight.SquareToTheRight.SquareToTheRight.Piece as Rook;
            var kingsideRookHasMoved = CurrentSquare.Board.History.Moves.Any(move => move.MovedPiece == kingsideRook);
            var kingsideIsFreeBetween = IsFree(CurrentSquare.SquareToTheRight, CurrentSquare.SquareToTheRight.SquareToTheRight);
            var kingsideWouldEndUpInCheck = CurrentSquare.SquareToTheRight.SquareToTheRight.IsThreatenedBy(Color.GetOpponent());

            if (kingsideRookHasMoved == false && kingsideIsFreeBetween && kingsideWouldEndUpInCheck == false)
            {
                yield return CurrentSquare.SquareToTheRight.SquareToTheRight;
            }

            var queensideRook = CurrentSquare.SquareToTheLeft.SquareToTheLeft.SquareToTheLeft.SquareToTheLeft.Piece as Rook;
            var queensideRookHasMoved = CurrentSquare.Board.History.Moves.Any(move => move.MovedPiece == queensideRook);
            var queensideIsFreeBetween = IsFree(CurrentSquare.SquareToTheLeft, CurrentSquare.SquareToTheLeft.SquareToTheLeft, CurrentSquare.SquareToTheLeft.SquareToTheLeft.SquareToTheLeft);
            var queensideWouldEndUpInCheck = CurrentSquare.SquareToTheLeft.SquareToTheLeft.IsThreatenedBy(Color.GetOpponent());

            if (queensideRookHasMoved == false && queensideIsFreeBetween && queensideWouldEndUpInCheck == false)
            {
                yield return CurrentSquare.SquareToTheLeft.SquareToTheLeft;
            }


            // TODO: Implement restrictions


        }

        private bool IsInCheck()
        {
            return CurrentSquare.IsThreatenedBy(Color.GetOpponent());
        }

        private bool IsFree(params Square[] squares)
        {
            return squares.All(square => square.IsFree());
        }
    }
}
