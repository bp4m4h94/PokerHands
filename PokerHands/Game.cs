namespace PokerHands;

public class Game
{
    public string ShowResult(string input)
    {
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        var parser = new Parser();
        var players = parser.Parse(input);
        
        
        var card1 = GetPokerHands(players[0])
            .First();
        var card2 = players[1]
            .Card.OrderByDescending(x => x.Value)
            .First();

        if (card2.Value > card1.Value)
        {
            var winnerPlayerName = players[1].Name;
            var winnerOutput =  card2
                .Output;
            return $"{winnerPlayerName} wins. - with high card: {winnerOutput}";
        }
        else
        {
            var winnerPlayerName = players[0].Name;
            var winnerOutput =  card1
                .Output;
            return $"{winnerPlayerName} wins. - with high card: {winnerOutput}";
        }
    }

    private static IOrderedEnumerable<Card> GetPokerHands(Player player)
    {
        return player
            .Card.OrderByDescending(x => x.Value);
    }
}