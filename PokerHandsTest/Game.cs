using PokerHands.Categories;
using PokerHands.Comparers;
using PokerHandsTest.Categories;

namespace PokerHands;

public class Game
{
    public string ShowResult(string input)
    {
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        var players = new Parser().Parse(input);


        var pokerHands1 = players[0].GetPokerHands();
        var pokerHands2 = players[1].GetPokerHands();

        IPokerHandsComparer comparer;
        if (pokerHands1.GetCategory().Type != pokerHands2.GetCategory().Type)
        {
            comparer = new PokerHandsComparer();
        }
        else
        {
            comparer = new HighCardComparer();
        }
        var compareResult = comparer.Compare(pokerHands1, pokerHands2);
        var winnerOutput = comparer.WinnerOutput;
        var winnerCategory = comparer.WinnerCategory;
        var winnerPlayer = compareResult < 0 ? players[1].Name : players[0].Name;

        if (compareResult != 0)
        {
            return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";
        }

        return "Tie.";
    }
}

internal class HighCard : Category
{
    public override CategoryType Type => CategoryType.HighCard;
    public override string Name => "high card";
}

internal class Pair : Category
{
    public override CategoryType Type => CategoryType.Pair;
    public override string Name => "pair";
}