using FluentAssertions;
using PokerHands.Categories;

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
    [Category("high card")]
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
    [Category("pair")]
    [Category("different category")]
    public void pair_win_others()
    {
        // pair compare with high card
        // player 1 wins
        ResultShouldBe("Black: 3H 4S 4C 2D 5H  White: 2S 8S AS QS 3S",
            "Black wins. - with pair: 4");
        // player2 wins
        ResultShouldBe("Black: 2S 8S AS QS 3S  White: 3H QS QC 2D 5H",
            "White wins. - with pair: Queen");
    }

    [Test]  
    [Category("pair")]
    [Category("same category")]
    public void both_pair()
    {
        ResultShouldBe("Black: 2H 3S TC TD KH  White: 2S 3S 3S 9S AS",
            "Black wins. - with pair: 10");

        ResultShouldBe("Black: 2S 8S KS QS QS  White: 3H QS QC AD 5H",
            "White wins. - with pair: Ace");
        
        ResultShouldBe("Black: 2S 8S KS QS QS  White: 3H QS QC KD 8H",
            "White wins. - with pair: 3");
        
        ResultShouldBe("Black: 2S 8S KS QS QS  White: 2S 8S KC QS QH",
            "Tie.");
    }
    
    [Test]  
    [Category("two pairs")]
    [Category("different category")]
    public void two_pairs_with_others()
    {
        ResultShouldBe("Black: 2H 2S TC TD KH  White: 2S TS JS 9S AS",
            "Black wins. - with two pairs: 10 over 2");

        ResultShouldBe("Black: 2S 8S KS TS QS  White: AH AS KC KD 5H",
            "White wins. - with two pairs: Ace over King");
        
    }
    [Test]  
    [Category("two pairs")]
    [Category("same category")]
    public void two_pairs()
    {
        ResultShouldBe("Black: 2H 2S TC TD KH  White: 3S 3S QS QS AS",
            "White wins. - with two pairs: Queen");

        ResultShouldBe("Black: 2H 2S QC TD QH  White: 3S 3S QS QS AS",
            "White wins. - with two pairs: 3");
        
        ResultShouldBe("Black: 2H 2S QC TD QH  White: 2S 2H QC TD QH",
            "Tie.");
    }

    private void ResultShouldBe(string input, string expected)
    {
        var showResult = _game.ShowResult(input);
        showResult.Should().Be(expected);
    }
}