using PokerHands.Categories;
using PokerHands.Comparers;

namespace PokerHands;

public class DifferentCategoryComparer
{
    public int DifferentCategoryCompare(Category category1, Category category2, out string winnerCategory,
        out string winnerOutput)
    {
        var compareResult = category1.Type - category2.Type;
        if (category1.Type > category2.Type)
        {
            winnerCategory = category1.Name;
            winnerOutput = category1.Output;
        }
        else
        {
            winnerCategory = category2.Name;
            winnerOutput = category2.Output;
        }

        return compareResult;
    }
}

public class Game
{
    private readonly DifferentCategoryComparer _differentCategoryComparer = new DifferentCategoryComparer();

    public string ShowResult(string input)
    {
        // Black: 2H 3D 5S 8C 6D  White: 2C 3H 4S 9C 5H
        var players = new Parser().Parse(input);


        var pokerHands1 = players[0].GetPokerHands();
        var pokerHands2 = players[1].GetPokerHands();

        var category1 = GetCategory(pokerHands1);
        var category2 = GetCategory(pokerHands2);

        int compareResult;
        string winnerPlayer;
        string? winnerCategory;
        string winnerOutput;
        if (category1.Type != category2.Type)
        {
            compareResult = _differentCategoryComparer.DifferentCategoryCompare(category1, category2, out winnerCategory, out winnerOutput);
        }
        else
        {
            var highCardComparer = new HighCardComparer();
            compareResult = highCardComparer.Compare(pokerHands1, pokerHands2);

            winnerOutput = highCardComparer.WinnerOutput;
            winnerCategory = highCardComparer.CategoryName;
        }
        winnerPlayer = compareResult < 0 ? players[1].Name : players[0].Name;

        if (compareResult != 0)
        {
            return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";
        }

        return "Tie.";
    }

    private static Category GetCategory(IOrderedEnumerable<Card> pokerHands)
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