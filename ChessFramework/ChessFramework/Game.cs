using System;

namespace ChessFramework
{
    public class Game
    {
        private Board _board = new Board();

        public event EventHandler NewTurn;

        public void Start()
        {
            NewTurn(this, EventArgs.Empty);
        }

        public void Resign()
        {
            
        }

        public void Move(Square from, Square to)
        {
            NewTurn(this, EventArgs.Empty);
        }
    }
}
