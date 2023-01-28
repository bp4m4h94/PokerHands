namespace PokerHands;

public class HighCardComparer
{
    public int Compare(IOrderedEnumerable<Card> pokerHands1, IOrderedEnumerable<Card> pokerHands2,
        out string? winnerOutput)
    {
        using var enumerator1 = pokerHands1.GetEnumerator();
        using var enumerator2 = pokerHands2.GetEnumerator();
        var compareResult = 0;
        winnerOutput = null;
        while (enumerator1.MoveNext() && enumerator2.MoveNext())
        {
            var card1 = enumerator1.Current;
            var card2 = enumerator2.Current;

            compareResult = card1.Value - card2.Value;
            if (compareResult != 0)
            {
                winnerOutput = compareResult < 0 ? card2.Output : card1.Output;
                break;
            }
        }

        return compareResult;
    }
}

public class Game
{
    private readonly HighCardComparer _highCardComparer = new HighCardComparer();

    public string ShowResult(string input)
    {
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        var players = new Parser().Parse(input);


        var pokerHands1 = players[0].GetPokerHands();
        var pokerHands2 = players[1].GetPokerHands();
        
        var compareResult = _highCardComparer.Compare(pokerHands1, pokerHands2, out var winnerOutput);

        if (compareResult != 0)
        {
            string winnerPlayerName = null;
            winnerPlayerName = compareResult < 0 ? players[1].Name : players[0].Name;

            return $"{winnerPlayerName} wins. - with high card: {winnerOutput}";
        }
        
        return "Tie.";
    }
}