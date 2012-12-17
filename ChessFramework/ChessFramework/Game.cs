﻿using System;

namespace ChessFramework
{
    public class Game
    {
        private bool hasStarted;
        private bool hasEnded;

        public event EventHandler NewTurn;
        public event EventHandler GameEnded;
        public Army? CurrentTurn { get; private set; }
        public Board Board { get; private set; }

        public Game()
        {
            CurrentTurn = null;
            Board = new Board();
        }

        public void Start()
        {
            if (hasStarted)
            {
                throw new InvalidOperationException("Game has already started.");
            }

            CurrentTurn = Army.White;
            hasStarted = true;
            OnNewTurn();
        }

        public void Resign()
        {
            if (hasEnded)
            {
                throw new InvalidOperationException("Game has already ended.");
            }

            CurrentTurn = null;
            hasEnded = true;
            OnGameEnded();
        }

        public void Move(Position from, Position to)
        {
            if (hasStarted == false)
            {
                throw new InvalidOperationException("Game hasn't been started.");
            }

            if (hasEnded)
            {
                throw new InvalidOperationException("Game has been ended.");
            }

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
