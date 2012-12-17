using System;
using System.Globalization;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ChessFramework.Specs.StepDefinitions
{
    [Binding]
    public class GameSteps
    {
        private Game _game;

        [Given(@"a new game")]
        public void GivenANewGame()
        {
            _game = new Game();
        }

        [When(@"the game starts")]
        public void WhenTheGameStarts()
        {
            _game.Start();
        }

        [Then(@"the board should look like")]
        public void ThenTheBoardShouldLookLike(Table table)
        {

            for (var verticalIndex = 0; verticalIndex < 8; verticalIndex++)
            {
                for (var hotizontalIndex = 0; hotizontalIndex < 8; hotizontalIndex++)
                {

                    var position = IndexToPosition(verticalIndex, hotizontalIndex);
                    var square = _game.Board[position];

                    var value = table.Rows[verticalIndex][hotizontalIndex];

                    if (string.IsNullOrWhiteSpace(value))
                    {
                        Assert.IsNull(square.Piece);
                    }
                    else
                    {
                        if (value.StartsWith("W"))
                        {
                            Assert.AreEqual(square.Piece.Color, Army.White);
                        }
                        else if (value.StartsWith("B"))
                        {
                            Assert.AreEqual(square.Piece.Color, Army.Black);
                        }
                        else
                        {
                            Assert.Fail("Invalid color specfied.");
                        }

                        if (value.EndsWith("Pa"))
                        {
                            Assert.IsInstanceOf<Pawn>(square.Piece);
                        }
                        else if (value.EndsWith("Ro"))
                        {
                            Assert.IsInstanceOf<Rook>(square.Piece);
                        }
                        else if (value.EndsWith("Kn"))
                        {
                            Assert.IsInstanceOf<Knight>(square.Piece);
                        }
                        else if (value.EndsWith("Bi"))
                        {
                            Assert.IsInstanceOf<Bishop>(square.Piece);
                        }
                        else if (value.EndsWith("Qu"))
                        {
                            Assert.IsInstanceOf<Queen>(square.Piece);
                        }
                        else if (value.EndsWith("Ki"))
                        {
                            Assert.IsInstanceOf<King>(square.Piece);
                        }
                        else
                        {
                            Assert.Fail("Invalid piece type specified.");
                        }
                    }
                }
            }
        }

        private static Position IndexToPosition(int verticalIndex, int hotizontalIndex)
        {
            var verticalPosition = (8 - verticalIndex).ToString(CultureInfo.InvariantCulture);
            var horizontalPosition = string.Empty;
            switch (hotizontalIndex)
            {
                case 0:
                    horizontalPosition = "a";
                    break;

                case 1:
                    horizontalPosition = "b";
                    break;

                case 2:
                    horizontalPosition = "c";
                    break;

                case 3:
                    horizontalPosition = "d";
                    break;

                case 4:
                    horizontalPosition = "e";
                    break;

                case 5:
                    horizontalPosition = "f";
                    break;

                case 6:
                    horizontalPosition = "g";
                    break;

                case 7:
                    horizontalPosition = "h";
                    break;
            }

            return new Position { HorizontalPosition = horizontalPosition, VerticalPosition = verticalPosition };
        }

        [Then(@"it should be (.*)")]
        public void ThenItShouldBeTurn(Army army)
        {
            Assert.AreEqual(army, _game.CurrentTurn);
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
    }
}
