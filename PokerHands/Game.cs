namespace PokerHands;

public class Game
{
    public string ShowResult(string input)
    {
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        var parser = new Parser();
        var players = parser.Parse(input);
        
        
        var card1 = players[0].GetPokerHands()
            .First();
        var card2 = players[1].GetPokerHands()
            .First();

        string winnerPlayerName;
        string winnerOutput;
        
        if (card2.Value > card1.Value)
        {
            winnerPlayerName = players[1].Name;
            winnerOutput = card2
                .Output;
        }
        else
        {
            winnerPlayerName = players[0].Name;
            winnerOutput = card1
                .Output;
        }
        return $"{winnerPlayerName} wins. - with high card: {winnerOutput}";
    }
}