using System;

namespace ChessFramework
{
    public class Game
    {
        private bool _hasStarted;
        private bool _hasEnded;

        public event EventHandler NewTurn;
        public event EventHandler GameEnded;
        public Army? CurrentTurn { get; private set; }
        public Board Board { get; private set; }
        public MoveHistory History { get; private set; }

        public Game()
        {
            CurrentTurn = null;
            Board = new Board();
            History = new MoveHistory();
        }

        public void Start()
        {
            if (_hasStarted)
            {
                throw new InvalidOperationException("Game has already started.");
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
                throw new InvalidMoveException(from, to, "No piece to move at the location.");
            }

            if (piece.Color != CurrentTurn)
            {
                throw new InvalidMoveException(from, to, string.Format("It is not {0}'s turn to move.", piece.Color));
            }

            var pieceAtToPosition = Board[to].Piece;
            piece.Move(to);
            History.Moves.Add(new Move { From = from, To = to, CapturedPiece = pieceAtToPosition });

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
