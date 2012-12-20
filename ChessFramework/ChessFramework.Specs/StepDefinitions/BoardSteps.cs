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
            for (var rankIndex = 0; rankIndex < 8; rankIndex++)
            {
                for (var fileIndex = 0; fileIndex < 8; fileIndex++)
                {

                    var position = BoardHelper.IndexToPosition(rankIndex, fileIndex);
                    var square = ChessScenario.Board[position];

                    var value = table.Rows[rankIndex][fileIndex];

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
            for (var rankIndex = 0; rankIndex < 8; rankIndex++)
            {
                for (var fileIndex = 0; fileIndex < 8; fileIndex++)
                {
                    var position = BoardHelper.IndexToPosition(rankIndex, fileIndex);
                    var square = ChessScenario.Board[position];

                    var value = table.Rows[rankIndex][fileIndex];

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
