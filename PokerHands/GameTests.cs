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
        ResultShouldBe("Black: 2H 3D 5S 8C KD  White: 2C 3H 4S JC 5H",
            "Black wins. - with high card: King");
        ResultShouldBe("Black: 2H 3D 5S 8C KD  White: 2C 3H 4S 9C AH",
            "White wins. - with high card: Ace");
        
        // both high card tie
        ResultShouldBe("Black: 2H 3D 5S 8C KD  White: 2H 3D 5S KD 8C",
            "Tie.");
        
        // both high card decided winner by other card
        ResultShouldBe("Black: 2H 3D 5S 9C KD  White: 2H 3D 5S 8C KD",
            "Black wins. - with high card: 9");
        ResultShouldBe("Black: 2H 3D 5S 9C KD  White: 2H 3D 6S 9C KD",
            "White wins. - with high card: 6");
        ResultShouldBe("Black: 2H 4D 6S 9C KD  White: 2H 5D 6S 9C KD",
            "White wins. - with high card: 5");
    }

    [Test]
    public void pair_win_others()
    {
        // pair compare with high card
        ResultShouldBe("Black: 2H 4S 4C 2D 4H  White: 2S 8S AS QS 3S",
            "Black wins. - with pair: 4");
    }
    
    private void ResultShouldBe(string input, string expected)
    {
        var showResult = _game.ShowResult(input);
        showResult.Should().Be(expected);
    }
}