using System;

namespace ChessFramework
{
    public class Game
    {
        public event EventHandler NewTurn;
        public event EventHandler GameEnded;
        public Army? CurrentTurn { get; private set; }
        public Board Board { get; private set; }

        public Game()
        {
            Board = new Board();
            CurrentTurn = null;
        }

        public void Start()
        {
            CurrentTurn = Army.White;
            OnNewTurn();
        }

        public void Resign()
        {
            CurrentTurn = null;
            OnGameEnded();
        }

        public void Move(Position from, Position to)
        {
            var piece = Board[from].Piece;
            if (piece == null)
            {
                throw new InvalidMoveException(from, to, "No piece to move at the location.");
            }

            piece.Move(to);

            if (HasEnded())
            {
                OnGameEnded();
            }
            else
            {
                OnNewTurn();
            }
        }

        private void OnNewTurn()
        {
            if (NewTurn != null)
            {
                NewTurn(this, EventArgs.Empty);
            }
        }

        private void OnGameEnded()
        {
            if (GameEnded != null)
            {
                GameEnded(this, EventArgs.Empty);
            }
        }

        private bool HasEnded()
        {
            // ...
            return false;
        }
    }
}
