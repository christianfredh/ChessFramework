using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public abstract class Piece
    {
        public Army Color { get; set; }
        public Square CurrentSquare { get; set; }

        public void Move(Position to)
        {
            if (GetValidMoves().Contains(to) == false)
            {
                throw new InvalidMoveException(CurrentSquare.Position, to, string.Format("{0} to {1} is an invalid move.", CurrentSquare.Position, to));
            }

            CurrentSquare.Piece = null;
            CurrentSquare.Board[to].Piece = this;
            CurrentSquare.Board[to].Piece.CurrentSquare = CurrentSquare.Board[to];
        }

        public abstract IEnumerable<Position> GetValidMoves();
    }
}
