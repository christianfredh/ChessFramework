using System;

namespace ChessFramework
{
    public class IllegalMoveException : Exception
    {
        public SquareIdentifier From { get; private set; }
        public SquareIdentifier To { get; private set; }

        public IllegalMoveException(SquareIdentifier from, SquareIdentifier to, string message)
            : base(message)
        {
            From = from;
            To = to;
        }
    }
}