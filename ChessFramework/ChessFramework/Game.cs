using System;

namespace ChessFramework
{
    public class Game
    {
        public event EventHandler NewTurn;
        public Army CurrentTurn { get; private set; }
        public Board Board { get; private set; }

        public Game()
        {
            Board = new Board();
            CurrentTurn = Army.Nobody;
        }

        public void Start()
        {
            CurrentTurn = Army.White;
            OnNewTurn();
        }

        private void OnNewTurn()
        {
            if (NewTurn != null)
            {
                NewTurn(this, EventArgs.Empty);
            }
        }

        public void Resign()
        {
            //...
            CurrentTurn = Army.Nobody;
        }

        public void Move(Square from, Square to)
        {
            //...
            OnNewTurn();
        }
    }
}
