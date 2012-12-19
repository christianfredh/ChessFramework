using System.Linq;
using ChessFramework.Specs.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ChessFramework.Specs.StepDefinitions
{
    [Binding]
    public class MovingSteps
    {
        [When(@"(.*) move (.*) to (.*)")]
        public void WhenMoving(string textColor, string from, string to)
        {
            var color = BoardHelper.ToArmyColor(textColor);
            Assert.AreEqual(color, ChessScenario.Game.CurrentTurn);

            ChessScenario.Game.Move(new Position(from), new Position(to));
        }

        [Then(@"then there should be a (.*) (.*) at (.*)")]
        public void ThenThereShouldBe(string textColor, string textPieceType, string textPosition)
        {
            var position = new Position(textPosition);
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
            var position = new Position(textPosition);
            Assert.IsNull(ChessScenario.Board[position].Piece);
        }

        [Then(@"a black pawn should be captured")]
        public void ThenABlackPawnShouldBeCaptured()
        {
            Assert.AreEqual(1, ChessScenario.Game
                                       .History
                                       .Moves
                                       .Count(move =>
                                            move.CapturedPiece != null &&
                                            move.CapturedPiece.Color == Army.Black &&
                                            move.CapturedPiece is Pawn));
        }
    }
}
