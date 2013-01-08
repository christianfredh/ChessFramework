namespace ChessFramework
{
    public class Move
    {
        public SquareIdentifier From { get; set; }
        public SquareIdentifier To { get; set; }
        public Piece MovedPiece { get; set; }
        public Piece CapturedPiece { get; set; }
    }
}
