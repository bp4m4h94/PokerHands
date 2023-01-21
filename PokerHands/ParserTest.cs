using FluentAssertions;
using NUnit.Framework;

namespace PokerHands;

[TestFixture]
public class ParserTest
{
    [Test]
    public void parse_player()
    {
        var parser = new Parser();
        var players = parser.Parse("Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C TH");
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
            new Player() 
            {  
                Name = "White", 
                Card = new List<Card>() 
                {
                    new Card(){Suit="C", Value=2, Output="2"}, 
                    new Card(){Suit="H", Value=3, Output="3"},
                    new Card(){Suit="S", Value=4, Output="4"},  
                    new Card(){Suit="C", Value=9, Output="9"},  
                    new Card(){Suit="H", Value=10, Output="10"}, 
                }  
            } 
        }, option => option.WithStrictOrdering());
    }
}