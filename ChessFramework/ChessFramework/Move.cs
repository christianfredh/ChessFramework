namespace ChessFramework
{
    public class Move
    {
        public Position From { get; set; }
        public Position To { get; set; }
        public Piece CapturedPiece { get; set; }
    }
}
