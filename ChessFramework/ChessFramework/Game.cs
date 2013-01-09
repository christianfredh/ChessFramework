using System;
using System.Linq;

namespace ChessFramework
{
    public class Game
    {
        private bool _hasStarted;
        private bool _hasEnded;

        public event EventHandler NewTurn;
        public event EventHandler GameEnded;
        public Army? CurrentTurn { get; private set; }
        public Army? Winner { get; private set; }
        public Board Board { get; private set; }

        public Func<PromotionChoice> PromotionChoice
        {
            get { return Board.PromotionChoice; }
            set { Board.PromotionChoice = value; }
        }

        public Game()
        {
            CurrentTurn = null;
            Board = new Board();
        }

        public void Start()
        {
            if (_hasStarted)
            {
                throw new InvalidOperationException("Game has already started.");
            }

            if (PromotionChoice == null)
            {
                throw new InvalidOperationException("Game must have a way of promoting a pawn.");
            }

            CurrentTurn = Army.White;
            _hasStarted = true;
            OnNewTurn();
        }

        public void Resign()
        {
            if (_hasEnded)
            {
                throw new InvalidOperationException("Game has already ended.");
            }

            Winner = CurrentTurn == Army.White ? Army.Black : Army.White;
            CurrentTurn = null;
            _hasEnded = true;
            OnGameEnded();
        }

        public void Move(SquareIdentifier from, SquareIdentifier to)
        {
            if (_hasStarted == false)
            {
                throw new InvalidOperationException("Game hasn't been started.");
            }

            if (_hasEnded)
            {
                throw new InvalidOperationException("Game has been ended.");
            }

            var piece = Board[from].Piece;
            if (piece == null)
            {
                throw new IllegalMoveException(from, to, "No piece to move at the location.");
            }

            if (piece.Color != CurrentTurn)
            {
                throw new IllegalMoveException(from, to, string.Format("It is not {0}'s turn to move.", piece.Color));
            }

            piece.Move(to);

            if (HasEnded())
            {
                OnGameEnded();
            }
            else
            {
                CurrentTurn = CurrentTurn == Army.White
                                  ? Army.Black
                                  : Army.White;
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
