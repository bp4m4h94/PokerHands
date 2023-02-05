using PokerHands.Comparers;
using PokerHandsTest.Categories;

namespace PokerHands;

public class Game
{
    private static Dictionary<CategoryType, IPokerHandsComparer> SameCompareLookup;

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
        var categoryType1 = pokerHands1.GetCategory().Type;
        var categoryType2 = pokerHands2.GetCategory().Type;
        
        if (categoryType1 != categoryType2)
        {
            return new DifferentCategoryComparer();
        }

        var compareLookup = new Dictionary<CategoryType, IPokerHandsComparer>()
        {
            { CategoryType.HighCard , new HighCardComparer()},
            { CategoryType.Pair , new PairComparer()}
        };
        SameCompareLookup = compareLookup;
        return SameCompareLookup[categoryType1];
    }
}