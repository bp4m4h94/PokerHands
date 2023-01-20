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
        players.Should().BeEquivalentTo(new List<Player> { 
        new Player() { Name = "Black" }, 
        new Player() { Name = "White" } 
        }, option => option.WithStrictOrdering());
    }
}