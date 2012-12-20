using System;
using System.Globalization;

namespace ChessFramework.Specs.StepDefinitions
{
    public static class BoardHelper
    {
        public static Position IndexToPosition(int rankIndex, int fileIndex)
        {
            var rank = (8 - rankIndex).ToString(CultureInfo.InvariantCulture)[0];
            char file;
            switch (fileIndex)
            {
                case 0:
                    file = 'a';
                    break;

                case 1:
                    file = 'b';
                    break;

                case 2:
                    file = 'c';
                    break;

                case 3:
                    file = 'd';
                    break;

                case 4:
                    file = 'e';
                    break;

                case 5:
                    file = 'f';
                    break;

                case 6:
                    file = 'g';
                    break;

                case 7:
                    file = 'h';
                    break;

                default:
                    throw new ArgumentOutOfRangeException("fileIndex", "Invalid file index.");
            }

            return new Position(file, rank);
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
