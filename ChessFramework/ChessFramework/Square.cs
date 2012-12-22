using System.Diagnostics;

namespace ChessFramework
{
    [DebuggerDisplay("Identifier: {Identifier.ToString()} Piece: {Piece != null ? Piece.Color.ToString() + \" \" + Piece.GetType().Name : \"None\",nq}")]
    public class Square
    {
        public Board Board { get; set; }
        public SquareIdentifier Identifier { get; set; }
        public Piece Piece { get; set; }

        public SquareColor Color
        {
            get
            {
                return (Identifier.File + Identifier.Rank) % 2 == 1
                    ? SquareColor.White
                    : SquareColor.Black;
            }
        }

        public Square SquareToTheRight
        {
            get
            {
                var newFile = (char)(Identifier.File + 1);
                return SquareIdentifier.IsValidFile(newFile)
                    ? Board[new SquareIdentifier(newFile, Identifier.Rank)]
                    : null;
            }
        }

        public Square SquareToTheLeft
        {
            get
            {
                var newFile = (char)(Identifier.File - 1);
                return SquareIdentifier.IsValidFile(newFile)
                    ? Board[new SquareIdentifier(newFile, Identifier.Rank)]
                    : null;
            }
        }

        public Square SquareAbove
        {
            get
            {
                var newRank = (char)(Identifier.Rank + 1);
                return SquareIdentifier.IsValidRank(newRank)
                    ? Board[new SquareIdentifier(Identifier.File, newRank)]
                    : null;
            }
        }

        public Square SquareBelow
        {
            get
            {
                var newRank = (char)(Identifier.Rank - 1);
                return SquareIdentifier.IsValidRank(newRank)
                    ? Board[new SquareIdentifier(Identifier.File, newRank)]
                    : null;
            }
        }

        public Square SquareDiagonallyUpAndRight
        {
            get
            {
                return SquareAbove != null
                    ? SquareAbove.SquareToTheRight
                    : null;
            }
        }

        public Square SquareDiagonallyUpAndLeft
        {
            get
            {
                return SquareAbove != null
                    ? SquareAbove.SquareToTheLeft
                    : null;
            }
        }

        public Square SquareDiagonallyDownAndRight
        {
            get
            {
                return SquareBelow != null
                    ? SquareBelow.SquareToTheRight
                    : null;
            }
        }

        public Square SquareDiagonallyDownAndLeft
        {
            get
            {
                return SquareBelow != null
                    ? SquareBelow.SquareToTheLeft
                    : null;
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