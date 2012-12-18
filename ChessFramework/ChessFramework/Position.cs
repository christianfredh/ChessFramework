using System;

namespace ChessFramework
{
    public struct Position
    {
        public string HorizontalPosition { get; set; }
        public string VerticalPosition { get; set; }

        public Position(string positionText) : this()
        {
            if (positionText == null)
            {
                throw new ArgumentNullException("positionText", "Position text cannot be null.");
            }

            if (positionText.Length != 2)
            {
                throw new ArgumentException("Position text must be two characters, first a-h followed by 1-8.");
            }

            //...

            HorizontalPosition = positionText[0].ToString();
            VerticalPosition = positionText[1].ToString();
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(HorizontalPosition) || 
                string.IsNullOrEmpty(VerticalPosition))
            {
                return string.Empty;
            }

            return string.Concat(HorizontalPosition, VerticalPosition);
        }
    }
}