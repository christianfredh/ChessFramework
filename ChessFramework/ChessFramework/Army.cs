namespace ChessFramework
{
    public enum Army
    {
        White,
        Black
    }

    public static class ArmyExtensions
    {
        public static Army GetOpponent(this Army army)
        {
            return army == Army.White 
                ? Army.Black 
                : Army.White;
        }
    }
}
