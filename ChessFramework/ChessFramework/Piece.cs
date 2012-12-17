using System.Collections.Generic;

namespace ChessFramework
{
    public abstract class Piece
    {
        public Army Color { get; set; }
        public Square CurrentSquare { get; set; }

        public abstract IEnumerable<Position> GetValidMoves();
        public abstract void Move(Position to);
    }
}
