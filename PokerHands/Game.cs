namespace PokerHands;

public class Game
{
    public string ShowResult(string input)
    {
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        var parser = new Parser();
        var winnerPlayerName = parser.Parse(input)[1].Name;
        var winnerOutput =  parser
            .Parse(input)[1]
            .Card.OrderByDescending(x => x.Value)
            .First()
            .Output;

        return $"{winnerPlayerName} wins. - with high card: {winnerOutput}";
    }
}