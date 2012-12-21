using System;

namespace ChessFramework
{
    public struct SquareIdentifier
    {
        public char File { get; set; }
        public char Rank { get; set; }

        public SquareIdentifier(char file, char rank)
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

        public SquareIdentifier(string label)
            : this()
        {
            if (label == null)
            {
                throw new ArgumentNullException("label", "Label cannot be null.");
            }

            if (label.Length != 2)
            {
                throw new ArgumentException("Label must be two characters, first a-h followed by 1-8.");
            }

            var file = label[0];
            var rank = label[1];

            if (IsValidFile(file) == false)
            {
                throw new ArgumentOutOfRangeException("label", string.Format("'{0}' is not a valid file.", file));
            }

            if (IsValidRank(rank) == false)
            {
                throw new ArgumentOutOfRangeException("label", string.Format("'{0}' is not a valid rank.", rank));
            }

            File = file;
            Rank = rank;
        }

        public SquareIdentifier? PositionToTheRight
        {
            get
            {
                var newFile = (char)(File + 1);
                if (IsValidFile(newFile))
                {
                    return new SquareIdentifier(newFile, Rank);
                }

                return null;
            }
        }

        public SquareIdentifier? PositionToTheLeft
        {
            get
            {
                var newFile = (char)(File - 1);
                if (IsValidFile(newFile))
                {
                    return new SquareIdentifier(newFile, Rank);
                }

                return null;
            }
        }

        public SquareIdentifier? PositionAbove
        {
            get
            {
                var newRank = (char)(Rank + 1);
                if (IsValidRank(newRank))
                {
                    return new SquareIdentifier(File, newRank);
                }

                return null;
            }
        }

        public SquareIdentifier? PositionBelow
        {
            get
            {
                var newRank = (char)(Rank - 1);
                if (IsValidRank(newRank))
                {
                    return new SquareIdentifier(File, newRank);
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