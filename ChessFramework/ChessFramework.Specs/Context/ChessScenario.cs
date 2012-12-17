using TechTalk.SpecFlow;

namespace ChessFramework.Specs.Context
{
    public static class ChessScenario
    {
        public static Game Game
        {
            get { return ScenarioContext.Current.Get<Game>("Game"); }
            set { ScenarioContext.Current["Game"] = value; }
        }

        public static Board Board
        {
            get
            {
                Board board;
                if (ScenarioContext.Current.TryGetValue("Board", out board) == false)
                {
                    board = Game.Board;
                }

                return board;
            }
            set { ScenarioContext.Current["Board"] = value; }
        }
    }
}
