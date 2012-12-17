using System;

namespace ChessFramework
{
    public class InvalidMoveException : Exception
    {
        public Position From { get; private set; }
        public Position To { get; private set; }

        public InvalidMoveException(Position from, Position to, string message)
            : base(message)
        {
            From = from;
            To = to;
        }
    }
}