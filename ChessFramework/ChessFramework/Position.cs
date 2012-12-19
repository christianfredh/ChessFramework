using System;

namespace ChessFramework
{
    public struct Position
    {
        public char HorizontalPosition { get; set; }
        public char VerticalPosition { get; set; }

        public Position(char horizontalPosition, char verticalPosition)
            : this()
        {
            if (IsValidHorizontalPosition(horizontalPosition) == false)
            {
                throw new ArgumentOutOfRangeException("horizontalPosition", string.Format("'{0}' is not a valid horizontal position.", horizontalPosition));
            }

            if (IsValidVerticalPosition(verticalPosition) == false)
            {
                throw new ArgumentOutOfRangeException("verticalPosition", string.Format("'{0}' is not a valid vertical position.", verticalPosition));
            }

            HorizontalPosition = horizontalPosition;
            VerticalPosition = verticalPosition;
        }

        public Position(string positionText)
            : this()
        {
            if (positionText == null)
            {
                throw new ArgumentNullException("positionText", "Position text cannot be null.");
            }

            if (positionText.Length != 2)
            {
                throw new ArgumentException("Position text must be two characters, first a-h followed by 1-8.");
            }

            var horizontalPosition = positionText[0];
            var verticalPosition = positionText[1];

            if (IsValidHorizontalPosition(horizontalPosition) == false)
            {
                throw new ArgumentOutOfRangeException("positionText", string.Format("'{0}' is not a valid horizontal position.", horizontalPosition));
            }

            if (IsValidVerticalPosition(verticalPosition) == false)
            {
                throw new ArgumentOutOfRangeException("positionText", string.Format("'{0}' is not a valid vertical position.", verticalPosition));
            }

            HorizontalPosition = horizontalPosition;
            VerticalPosition = verticalPosition;
        }

        public Position? PositionToTheRight
        {
            get
            {
                var newHorizontalPosition = (char)(HorizontalPosition + 1);
                if (IsValidHorizontalPosition(newHorizontalPosition))
                {
                    return new Position(newHorizontalPosition, VerticalPosition);
                }

                return null;
            }
        }

        public Position? PositionToTheLeft
        {
            get
            {
                var newHorizontalPosition = (char)(HorizontalPosition - 1);
                if (IsValidHorizontalPosition(newHorizontalPosition))
                {
                    return new Position(newHorizontalPosition, VerticalPosition);
                }

                return null;
            }
        }

        public Position? PositionAbove
        {
            get
            {
                var newVerticalPosition = (char)(VerticalPosition + 1);
                if (IsValidVerticalPosition(newVerticalPosition))
                {
                    return new Position(HorizontalPosition, newVerticalPosition);
                }

                return null;
            }
        }

        public Position? PositionBelow
        {
            get
            {
                var newVerticalPosition = (char)(VerticalPosition - 1);
                if (IsValidVerticalPosition(newVerticalPosition))
                {
                    return new Position(HorizontalPosition, newVerticalPosition);
                }

                return null;
            }
        }

        public override string ToString()
        {
            if (IsValidHorizontalPosition(HorizontalPosition) == false ||
                IsValidVerticalPosition(VerticalPosition) == false)
            {
                return string.Empty;
            }

            return string.Concat(HorizontalPosition, VerticalPosition);
        }

        private static bool IsValidHorizontalPosition(char horizontalPosition)
        {
            return horizontalPosition >= 'a' && horizontalPosition <= 'h';
        }

        private static bool IsValidVerticalPosition(char verticalPosition)
        {
            return verticalPosition >= '1' && verticalPosition <= '8';
        }
    }
}