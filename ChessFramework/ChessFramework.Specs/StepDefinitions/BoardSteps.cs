using ChessFramework.Specs.Context;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ChessFramework.Specs.StepDefinitions
{
    [Binding]
    public class BoardSteps
    {
        [Given(@"a new board")]
        public void GivenANewBoard()
        {
            ChessScenario.Board = new Board();
        }

        [Then(@"the board colors should look like")]
        public void ThenTheBoardColorsShouldLookLike(Table table)
        {
            for (var verticalIndex = 0; verticalIndex < 8; verticalIndex++)
            {
                for (var hotizontalIndex = 0; hotizontalIndex < 8; hotizontalIndex++)
                {

                    var position = BoardHelpers.IndexToPosition(verticalIndex, hotizontalIndex);
                    var square = ChessScenario.Board[position];

                    var value = table.Rows[verticalIndex][hotizontalIndex];

                    if (value == "W")
                    {
                        Assert.AreEqual(SquareColor.White, square.Color);
                    }
                    else if (value == "B")
                    {
                        Assert.AreEqual(SquareColor.Black, square.Color);
                    }
                    else
                    {
                        Assert.Fail("Invalid color specified.");
                    }
                }
            }
        }

        [Then(@"the board should look like")]
        public void ThenTheBoardShouldLookLike(Table table)
        {
            for (var verticalIndex = 0; verticalIndex < 8; verticalIndex++)
            {
                for (var hotizontalIndex = 0; hotizontalIndex < 8; hotizontalIndex++)
                {
                    var position = BoardHelpers.IndexToPosition(verticalIndex, hotizontalIndex);
                    var square = ChessScenario.Board[position];

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
    }
}
