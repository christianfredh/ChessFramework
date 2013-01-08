using System;
using System.Globalization;
using ChessFramework.Specs.Context;
using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ChessFramework.Specs.StepDefinitions
{
    [Binding]
    public class GameSteps
    {
        [Given(@"a new game")]
        public void GivenANewGame()
        {
            ChessScenario.Game = new Game();
        }

        [Given(@"the game has just started")]
        [When(@"the game starts")]
        public void WhenTheGameStarts()
        {
            ChessScenario.Game.Start();
        }

        [Then(@"it should be (.*)")]
        public void ThenItShouldBeTurn(Army army)
        {
            ChessScenario.Game.CurrentTurn
                   .Should()
                   .Be(army);
        }

        [StepArgumentTransformation("(.*)'s turn")]
        public Army Turn(string armyText)
        {
            Army army;
            if (Enum.TryParse(armyText, true, out army) == false)
            {
                throw new ArgumentOutOfRangeException("armyText", armyText, "Army be be one of the following: White, Black or Nobody");
            }

            return army;
        }

        [When(@"(.*) resigns")]
        public void WhenWhiteResigns(string color)
        {
            var army = BoardHelper.ToArmyColor(color);
            ChessScenario.Game.CurrentTurn
                .Should()
                .Be(army);

            ChessScenario.Game.Resign();
        }

        [Then(@"(.*) should be the winner")]
        public void ThenBlackShouldBeTheWinner(string color)
        {
            var army = BoardHelper.ToArmyColor(color);
            ChessScenario.Game.Winner.Should().Be(army);
        }
    }
}
