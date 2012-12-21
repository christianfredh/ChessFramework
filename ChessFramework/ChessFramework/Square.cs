namespace ChessFramework
{
    public class Square
    {
        public Board Board { get; set; }
        public SquareIdentifier SquareIdentifier { get; set; }
        public SquareColor Color { get; set; }
        public Piece Piece { get; set; }

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