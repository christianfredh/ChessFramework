using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public class Pawn : Piece
    {
        public override IEnumerable<Position> GetValidMoves()
        {
            yield return new Position { HorizontalPosition = "e", VerticalPosition = "3" };
            yield return new Position { HorizontalPosition = "e", VerticalPosition = "4" };
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
    }
}
