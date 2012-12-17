using System;
using System.Globalization;
using ChessFramework.Specs.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ChessFramework.Specs.StepDefinitions
{
    [Binding]
    public class MovingSteps
    {
        [When(@"I move (.*) to (.*)")]
        public void WhenIMove(string from, string to)
        {
            ChessScenario.Game.Move(BoardHelper.ToPosition(from), BoardHelper.ToPosition(to));
        }

        [Then(@"then there should be a (.*) (.*) at (.*)")]
        public void ThenThereShouldBe(string textColor, string textPieceType, string textPosition)
        {
            var position = BoardHelper.ToPosition(textPosition);
            var color = BoardHelper.ToArmyColor(textColor);
            var pieceType = BoardHelper.ToPieceType(textPieceType);

            var piece = ChessScenario.Board[position].Piece;

            Assert.AreEqual(color, piece.Color);
            Assert.AreEqual(position, piece.CurrentSquare.Position);
            Assert.IsInstanceOf(pieceType, piece);

        }

        [Then(@"(.*) should be empty")]
        public void ThenPositionShouldBeEmpty(string textPosition)
        {
            var position = BoardHelper.ToPosition(textPosition);
            Assert.IsNull(ChessScenario.Board[position].Piece);
        }

    }
}
