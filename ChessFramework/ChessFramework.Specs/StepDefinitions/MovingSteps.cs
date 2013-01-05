using System.Collections.Generic;
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

            ChessScenario.Game.Move(new SquareIdentifier(from), new SquareIdentifier(to));
        }

        [Then(@"then there should be a (.*) (.*) at (.*)")]
        public void ThenThereShouldBe(string textColor, string textPieceType, string textPosition)
        {
            var position = new SquareIdentifier(textPosition);
            var color = BoardHelper.ToArmyColor(textColor);
            var pieceType = BoardHelper.ToPieceType(textPieceType);

            var piece = ChessScenario.Board[position].Piece;

            Assert.AreEqual(color, piece.Color);
            Assert.AreEqual(position, piece.CurrentSquare.Identifier);
            Assert.IsInstanceOf(pieceType, piece);

        }

        [Then(@"(.*) should be empty")]
        public void ThenPositionShouldBeEmpty(string textPosition)
        {
            var position = new SquareIdentifier(textPosition);
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

        [Then(@"(.*) should be able to move (.*) to")]
        public void ThenShouldBeAbleToMoveTo(string textColor, string textFrom, Table toOptions)
        {
            var color = BoardHelper.ToArmyColor(textColor);
            Assert.AreEqual(color, ChessScenario.Game.CurrentTurn);

            var from = new SquareIdentifier(textFrom);
            var piece = ChessScenario.Board[from].Piece;

            var tos = toOptions.Rows
                .Select(row => new SquareIdentifier(row[0]))
                .ToList();

            // TODO: FluentAssertions...

            var possibleMoves = piece.GetPossibleMoves().ToList();

            Assert.AreEqual(tos.Count(), possibleMoves.Count());

            foreach (var expectedMove in tos)
            {
                Assert.Contains(expectedMove, possibleMoves);
            }
        }
    }
}
