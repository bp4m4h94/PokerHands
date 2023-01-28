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

        string winnerPlayerName = null;
        string winnerOutput = null;

        var compareResult = card1.Value - card2.Value;
        if (compareResult != 0)
        {
            if (compareResult < 0)
            {
                winnerPlayerName = players[1].Name;
                winnerOutput = card2
                    .Output;
            }

            if (compareResult > 0)
            {
                winnerPlayerName = players[0].Name;
                winnerOutput = card1
                    .Output;
            }

            return $"{winnerPlayerName} wins. - with high card: {winnerOutput}";
        }
        return "Tie.";
    }
}