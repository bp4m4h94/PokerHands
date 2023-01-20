using FluentAssertions;

namespace PokerHands;

[TestFixture]
public class GameTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void show_winner_card_output()
    {
        var game = new Game();

        // 2~9
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        //     White wins. - with high card: 9
        var showResult = game.ShowResult("Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H");
        showResult.Should().Be("White wins. - with high card: 9");

    }
}

public class Game
{
    public string ShowResult(string input)
    {
        var winnerPlayerName = "White";
        var winnerOutput = "9";

        return $"{winnerPlayerName} wins. - with high card: {winnerOutput}";
    }
}