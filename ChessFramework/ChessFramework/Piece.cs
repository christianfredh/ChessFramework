﻿using System.Collections.Generic;
using System.Linq;

namespace ChessFramework
{
    public abstract class Piece
    {
        public Army Color { get; set; }
        public Square CurrentSquare { get; set; }

        public void Move(SquareIdentifier to)
        {
            if (GetValidMoves().Contains(to) == false)
            {
                throw new InvalidMoveException(CurrentSquare.SquareIdentifier, to, string.Format("{0} to {1} is an invalid move.", CurrentSquare.SquareIdentifier, to));
            }

            CurrentSquare.Piece = null;
            CurrentSquare.Board[to].Piece = this;
            CurrentSquare.Board[to].Piece.CurrentSquare = CurrentSquare.Board[to];
        }

        public abstract IEnumerable<SquareIdentifier> GetValidMoves();
    }
}
