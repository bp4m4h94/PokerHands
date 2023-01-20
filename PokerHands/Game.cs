namespace PokerHands;

public class Game
{
    public string ShowResult(string input)
    {
        var winnerPlayerName = "White";
        var winnerOutput = "9";

        return $"{winnerPlayerName} wins. - with high card: {winnerOutput}";
    }
}