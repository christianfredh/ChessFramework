﻿using System.Linq;
using ChessFramework.Specs.Context;
using FluentAssertions;
using TechTalk.SpecFlow;
using System;

namespace ChessFramework.Specs.StepDefinitions
{
    [Binding]
    public class MovingSteps
    {
        [When(@"(.*) move (.*) to (.*)")]
        public void WhenMoving(string textColor, string from, string to)
        {
            var color = BoardHelper.ToArmyColor(textColor);

            ChessScenario.Game.CurrentTurn
                .Should()
                .Be(color);

            ChessScenario.Game.Move(new SquareIdentifier(from), new SquareIdentifier(to));
        } 
        
        [When(@"(.*) is illegally moving (.*) to (.*)")]
        public void WhenTryingToDoAnIllegalMove(string textColor, string from, string to)
        {
            var color = BoardHelper.ToArmyColor(textColor);

            ChessScenario.Game.CurrentTurn
                .Should()
                .Be(color);

            Action move = () => ChessScenario.Game.Move(new SquareIdentifier(from), new SquareIdentifier(to));

            move.ShouldThrow<IllegalMoveException>();
        }

        [When(@"(.*) promotes to (.*) when moving (.*) to (.*)")]
        public void WhenMoving(string textColor, string promoteTo, string from, string to)
        {
            var promotionChoice = BoardHelper.ToPromotionChoice(promoteTo);
            ChessScenario.Game.PromotionChoice = () => promotionChoice;

            WhenMoving(textColor, from, to);
        }

        [Then(@"there should be a (.*) (.*) at (.*)")]
        public void ThenThereShouldBe(string textColor, string textPieceType, string textPosition)
        {
            var position = new SquareIdentifier(textPosition);
            var color = BoardHelper.ToArmyColor(textColor);
            var pieceType = BoardHelper.ToPieceType(textPieceType);

            var piece = ChessScenario.Board[position].Piece;

            piece.Should().NotBeNull(string.Format("there should be a piece at {0}", position));
            piece.Color.Should().Be(color);
            piece.CurrentSquare.Identifier.Should().Be(position);
            piece.GetType().Should().Be(pieceType);
        }

        [Then(@"(.*) should be empty")]
        public void ThenPositionShouldBeEmpty(string textPosition)
        {
            var position = new SquareIdentifier(textPosition);
            var square = ChessScenario.Board[position];

            square.Piece.Should().BeNull();
            square.IsFree().Should().BeTrue();
        }

        [Then(@"a black pawn should be captured")]
        public void ThenABlackPawnShouldBeCaptured()
        {
            ChessScenario.Game.Board.History.Moves
                         .Where(move =>
                                move.CapturedPiece != null &&
                                move.CapturedPiece.Color == Army.Black &&
                                move.CapturedPiece is Pawn)
                         .Should()
                         .HaveCount(1);
        }

        [Then(@"(.*) should be able to move (.*) to (.*)")]
        public void ThenShouldBeAbleToMoveTo(string textColor, string textFrom, string textTo)
        {
            var color = BoardHelper.ToArmyColor(textColor);
            ChessScenario.Game.CurrentTurn.Should().Be(color);

            var from = new SquareIdentifier(textFrom);
            var to = new SquareIdentifier(textTo);
            var piece = ChessScenario.Board[from].Piece;

            piece.GetPossibleMoves()
                .Should()
                .Contain(to);
        }


        [Then(@"(.*) should be able to move (.*) to")]
        public void ThenShouldBeAbleToMoveTo(string textColor, string textFrom, Table toOptions)
        {
            var color = BoardHelper.ToArmyColor(textColor);
            ChessScenario.Game.CurrentTurn.Should().Be(color);

            var from = new SquareIdentifier(textFrom);
            var piece = ChessScenario.Board[from].Piece;

            var tos = toOptions.Rows
                .Select(row => new SquareIdentifier(row[0]))
                .ToList();

            piece.GetPossibleMoves()
                .Should()
                .BeEquivalentTo(tos);
        }

        [Then(@"a total of (.*) moves should be registered")]
        public void ThenATotalOfMovesShouldBeRegistered(int totalMoves)
        {
            ChessScenario.Game.Board.History.Moves
                .Should()
                .HaveCount(totalMoves);
        }

        [Then(@"(.*) should not be able to move (.*) to (.*)")]
        public void ShouldNotBeAbleToMoveTo(string textColor, string textFrom, string textTo)
        {
            var color = BoardHelper.ToArmyColor(textColor);
            ChessScenario.Game.CurrentTurn.Should().Be(color);

            var from = new SquareIdentifier(textFrom);
            var piece = ChessScenario.Board[from].Piece;

            var to = new SquareIdentifier(textTo);

            piece.GetPossibleMoves()
                .Should()
                .NotContain(to);
        }

    }
}
