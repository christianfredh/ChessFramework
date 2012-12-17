namespace ChessFramework
{
    public struct Position
    {
        public string HorizontalPosition { get; set; }
        public string VerticalPosition { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(HorizontalPosition) || 
                string.IsNullOrWhiteSpace(VerticalPosition))
            {
                return string.Empty;
            }

            return string.Concat(HorizontalPosition, VerticalPosition);
        }
    }
}