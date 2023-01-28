namespace PokerHands;

public class Game
{
    public string ShowResult(string input)
    {
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        var players = new Parser().Parse(input);


        var pokerHands1 = players[0].GetPokerHands();
        var pokerHands2 = players[1].GetPokerHands();
        var enumerator1 = pokerHands1.GetEnumerator();
        var enumerator2 = pokerHands2.GetEnumerator();

        while (enumerator1.MoveNext() && enumerator2.MoveNext())
        {
            var card1 = enumerator1.Current;
            var card2 = enumerator2.Current;

            var compareResult = card1.Value - card2.Value;
            if (compareResult != 0)
            {
                string winnerPlayerName;
                string winnerOutput;
                if (compareResult < 0)
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
        return "Tie.";
    }
}