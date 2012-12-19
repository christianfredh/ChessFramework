using System;
using System.Globalization;

namespace ChessFramework.Specs.StepDefinitions
{
    public static class BoardHelper
    {
        public static Position IndexToPosition(int verticalIndex, int hotizontalIndex)
        {
            var verticalPosition = (8 - verticalIndex).ToString(CultureInfo.InvariantCulture)[0];
            char horizontalPosition;
            switch (hotizontalIndex)
            {
                case 0:
                    horizontalPosition = 'a';
                    break;

                case 1:
                    horizontalPosition = 'b';
                    break;

                case 2:
                    horizontalPosition = 'c';
                    break;

                case 3:
                    horizontalPosition = 'd';
                    break;

                case 4:
                    horizontalPosition = 'e';
                    break;

                case 5:
                    horizontalPosition = 'f';
                    break;

                case 6:
                    horizontalPosition = 'g';
                    break;

                case 7:
                    horizontalPosition = 'h';
                    break;

                default:
                    throw new ArgumentOutOfRangeException("hotizontalIndex", "Invalid horizontal index.");
            }

            return new Position(horizontalPosition, verticalPosition);
        }

        public static Army ToArmyColor(string color)
        {
            Army army;
            if (Enum.TryParse(color, true, out army) == false)
            {
                throw new ArgumentOutOfRangeException("color", "Invalid army color.");
            }

            return army;
        }

        public static Type ToPieceType(string textPieceType)
        {
            switch (textPieceType.ToLowerInvariant())
            {
                case "king":
                    return typeof(King);
                case "queen":
                    return typeof(Queen);
                case "bishop":
                    return typeof(Bishop);
                case "knight":
                    return typeof(Knight);
                case "rook":
                    return typeof(Rook);
                case "pawn":
                    return typeof(Pawn);
                default:
                    throw new ArgumentOutOfRangeException("textPieceType", "Invalid piece type.");
            }
        }
    }
}
