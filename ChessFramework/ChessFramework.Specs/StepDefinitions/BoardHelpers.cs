using System.Globalization;

namespace ChessFramework.Specs.StepDefinitions
{
    public static class BoardHelpers
    {
        public static Position IndexToPosition(int verticalIndex, int hotizontalIndex)
        {
            var verticalPosition = (8 - verticalIndex).ToString(CultureInfo.InvariantCulture);
            var horizontalPosition = string.Empty;
            switch (hotizontalIndex)
            {
                case 0:
                    horizontalPosition = "a";
                    break;

                case 1:
                    horizontalPosition = "b";
                    break;

                case 2:
                    horizontalPosition = "c";
                    break;

                case 3:
                    horizontalPosition = "d";
                    break;

                case 4:
                    horizontalPosition = "e";
                    break;

                case 5:
                    horizontalPosition = "f";
                    break;

                case 6:
                    horizontalPosition = "g";
                    break;

                case 7:
                    horizontalPosition = "h";
                    break;
            }

            return new Position { HorizontalPosition = horizontalPosition, VerticalPosition = verticalPosition };
        }
    }
}
