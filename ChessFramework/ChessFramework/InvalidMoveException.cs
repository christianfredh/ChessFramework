using System;

namespace ChessFramework
{
    public class InvalidMoveException : Exception
    {
        public SquareIdentifier From { get; private set; }
        public SquareIdentifier To { get; private set; }

        public InvalidMoveException(SquareIdentifier from, SquareIdentifier to, string message)
            : base(message)
        {
            From = from;
            To = to;
        }
    }
}