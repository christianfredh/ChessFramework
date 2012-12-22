namespace ChessFramework
{
    public class Square
    {
        public Board Board { get; set; }
        public SquareIdentifier Identifier { get; set; }
        public Piece Piece { get; set; }

        public SquareColor Color
        {
            get
            {
                if ((Identifier.File + Identifier.Rank) % 2 == 1)
                {
                    return SquareColor.White;
                }

                return SquareColor.Black;
            }
        }

        public Square SquareToTheRight
        {
            get
            {
                var newFile = (char)(Identifier.File + 1);
                if (SquareIdentifier.IsValidFile(newFile))
                {
                    return Board[new SquareIdentifier(newFile, Identifier.Rank)];
                }

                return null;
            }
        }

        public Square SquareToTheLeft
        {
            get
            {
                var newFile = (char)(Identifier.File - 1);
                if (SquareIdentifier.IsValidFile(newFile))
                {
                    return Board[new SquareIdentifier(newFile, Identifier.Rank)];
                }

                return null;
            }
        }

        public Square SquareAbove
        {
            get
            {
                var newRank = (char)(Identifier.Rank + 1);
                if (SquareIdentifier.IsValidRank(newRank))
                {
                    return Board[new SquareIdentifier(Identifier.File, newRank)];
                }

                return null;
            }
        }

        public Square SquareBelow
        {
            get
            {
                var newRank = (char)(Identifier.Rank - 1);
                if (SquareIdentifier.IsValidRank(newRank))
                {
                    return Board[new SquareIdentifier(Identifier.File, newRank)];
                }

                return null;
            }
        }

        public bool IsFree()
        {
            return Piece == null;
        }

        public bool IsOccupied()
        {
            return IsFree() == false;
        }
    }
}