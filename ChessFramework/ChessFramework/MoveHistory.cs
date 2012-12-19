using System.Collections.Generic;

namespace ChessFramework
{
    public class MoveHistory
    {
        public MoveHistory()
        {
            Moves = new List<Move>();
        }

        public IList<Move> Moves { get; private set; }
    }
}