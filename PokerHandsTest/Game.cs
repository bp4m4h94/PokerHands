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

        var comparer = GetComparer(pokerHands1, pokerHands2);

        var compareResult = comparer.Compare(pokerHands1, pokerHands2);
        var winnerOutput = comparer.WinnerOutput;

        if (compareResult != 0)
        {
            var winnerCategory = comparer.WinnerCategory;
            var winnerPlayer = compareResult < 0 ? players[1].Name : players[0].Name;
            return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";
        }

        return "Tie.";
    }

    private static IPokerHandsComparer GetComparer(PokerHands pokerHands1, PokerHands pokerHands2)
    {
        if (pokerHands1.GetCategory().Type != pokerHands2.GetCategory().Type)
        {
            return new DifferentCategoryComparer();
        }

        if (pokerHands1.GetCategory().Type == CategoryType.Pair)
        {
            return new PairComparer();
        }
        return new HighCardComparer();
    }
}

internal class PairComparer: IPokerHandsComparer
{
    public int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
    {
        var pair1 = pokerHands1.GroupBy(x =>　x.Value)
            .Where(x => x.Count() == 2);
        var pair2 = pokerHands2.GroupBy(x => x.Value)
            .Where(x => x.Count() == 2);
        var compareResult = pair1.First().First().Value - pair2.First().First().Value;
        WinnerOutput = compareResult > 0 ? pair1.First().First().Output : pair2.First().First().Output;
        return compareResult;
    }

    public string WinnerOutput { get; private set; }

    public string WinnerCategory => "pair";
}