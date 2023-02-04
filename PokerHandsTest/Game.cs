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

        var category1 = GetCategory(pokerHands1);
        var category2 = GetCategory(pokerHands2);

        int compareResult;
        string? winnerCategory;
        string winnerOutput;
        if (category1.Type != category2.Type)
        {
            var differentCategoryComparer = new DifferentCategoryComparer();
            compareResult = differentCategoryComparer.Compare(category1, category2);
            winnerOutput = differentCategoryComparer.WinnerOutput;
            winnerCategory = differentCategoryComparer.WinnerCategory;
        }
        else
        {
            var highCardComparer = new HighCardComparer();
            compareResult = highCardComparer.Compare(pokerHands1, pokerHands2);
            winnerOutput = highCardComparer.WinnerOutput;
            winnerCategory = highCardComparer.WinneCategory;
        }
        var winnerPlayer = compareResult < 0 ? players[1].Name : players[0].Name;

        if (compareResult != 0)
        {
            return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";
        }

        return "Tie.";
    }

    private static Category GetCategory(IEnumerable<Card> pokerHands)
    {
        var pairs  = pokerHands
            .GroupBy(x => x.Value)
            .Where(x => x.Count() == 2);
        var isPair = pairs.Any();
        if (isPair)
        {
            return new Pair { Output = pairs.First().First().Output };
        }

        return new HighCard();
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