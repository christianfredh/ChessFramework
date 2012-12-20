using System;

namespace ChessFramework
{
    public struct Position
    {
        public char File { get; set; }
        public char Rank { get; set; }

        public Position(char file, char rank)
            : this()
        {
            if (IsValidFile(file) == false)
            {
                throw new ArgumentOutOfRangeException("file", string.Format("'{0}' is not a valid file.", file));
            }

            if (IsValidRank(rank) == false)
            {
                throw new ArgumentOutOfRangeException("rank", string.Format("'{0}' is not a valid rank.", rank));
            }

            File = file;
            Rank = rank;
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

            var file = positionText[0];
            var rank = positionText[1];

            if (IsValidFile(file) == false)
            {
                throw new ArgumentOutOfRangeException("positionText", string.Format("'{0}' is not a valid file.", file));
            }

            if (IsValidRank(rank) == false)
            {
                throw new ArgumentOutOfRangeException("positionText", string.Format("'{0}' is not a valid rank.", rank));
            }

            File = file;
            Rank = rank;
        }

        public Position? PositionToTheRight
        {
            get
            {
                var newFile = (char)(File + 1);
                if (IsValidFile(newFile))
                {
                    return new Position(newFile, Rank);
                }

                return null;
            }
        }

        public Position? PositionToTheLeft
        {
            get
            {
                var newFile = (char)(File - 1);
                if (IsValidFile(newFile))
                {
                    return new Position(newFile, Rank);
                }

                return null;
            }
        }

        public Position? PositionAbove
        {
            get
            {
                var newRank = (char)(Rank + 1);
                if (IsValidRank(newRank))
                {
                    return new Position(File, newRank);
                }

                return null;
            }
        }

        public Position? PositionBelow
        {
            get
            {
                var newRank = (char)(Rank - 1);
                if (IsValidRank(newRank))
                {
                    return new Position(File, newRank);
                }

                return null;
            }
        }

        public override string ToString()
        {
            if (IsValidFile(File) == false ||
                IsValidRank(Rank) == false)
            {
                return string.Empty;
            }

            return string.Concat(File, Rank);
        }

        private static bool IsValidFile(char file)
        {
            return file >= 'a' && file <= 'h';
        }

        private static bool IsValidRank(char rank)
        {
            return rank >= '1' && rank <= '8';
        }
    }
}