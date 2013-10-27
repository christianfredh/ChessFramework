using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class King : Piece
    {
        private bool _hasMoved;

        public override void Move(SquareIdentifier to)
        {
            var castelingMoves = GetCastelingMoves()
                .Select(square => square.Identifier)
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

            base.Move(to);

            _hasMoved = true;
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
            if (_hasMoved)
            {
                yield break;
            }

            var kingsideRock = CurrentSquare.SquareToTheRight.SquareToTheRight.SquareToTheRight.Piece as Rook;

            if (CurrentSquare.Board.History.Moves
                .Any(move => move.MovedPiece == kingsideRock) == false)
            {
                yield return CurrentSquare.SquareToTheRight.SquareToTheRight;
            }

            var queensideRock = CurrentSquare.SquareToTheLeft.SquareToTheLeft.SquareToTheLeft.SquareToTheLeft.Piece as Rook;

            if (CurrentSquare.Board.History.Moves
                .Any(move => move.MovedPiece == queensideRock) == false)
            {
                yield return CurrentSquare.SquareToTheLeft.SquareToTheLeft;
            }


            // TODO: Implement restrictions

            
        }
    }
}
