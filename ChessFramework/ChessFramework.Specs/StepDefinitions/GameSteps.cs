using TechTalk.SpecFlow;

namespace ChessFramework.Specs.StepDefinitions
{
    [Binding]
    public class GameSteps
    {
        [Given(@"a new game")]
        public void GivenANewGame()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the game starts")]
        public void WhenTheGameStarts()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the board should look like")]
        public void ThenTheBoardShouldLookLike(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it should be White's turn")]
        public void ThenItShouldBeWhiteSTurn()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
