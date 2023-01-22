using FluentAssertions;

namespace PokerHands;

[TestFixture]
public class GameTests
{
    private Game _game;

    [SetUp]
    public void Setup()
    {
        _game = new Game();
    }

    [Test]
    public void show_winner_card_output()
    {
        // 2~9
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        //     White wins. - with high card: 9
        ResultShouldBe("Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H",
            "White wins. - with high card: 9");
        ResultShouldBe("Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H",
            "Black wins. - with high card: King");
    }

    private void ResultShouldBe(string input, string expected)
    {
        var showResult = _game.ShowResult(input);
        showResult.Should().Be(expected);
    }
}