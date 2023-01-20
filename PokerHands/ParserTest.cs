using FluentAssertions;
using NUnit.Framework;

namespace PokerHands;

[TestFixture]
public class ParserTest
{
    [Test]
    public void parse_player_name()
    {
        var parser = new Parser();
        var players = parser.Parse("Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H");
        players.Should().BeEquivalentTo(new List<Player> 
        { 
            new Player() 
            { 
                Name = "Black", 
                Card = new List<Card>() 
                {
                    new Card(){Suit="H", Value=2, Output="2"}, 
                    new Card(){Suit="D", Value=3, Output="3"},  
                    new Card(){Suit="S", Value=5, Output="5"},  
                    new Card(){Suit="C", Value=8, Output="8"},  
                    new Card(){Suit="D", Value=6, Output="6"}, 
                } 
            }, 
            new Player() { Name = "White" } 
        }, option => option.WithStrictOrdering());
    }
}