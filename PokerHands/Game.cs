using PokerHands.Categories;
using PokerHands.Comparers;

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

        if (category1.Type != category2.Type)
        {
            string winnerPlayer;
            string? winnerCategory;
            string winnerOutput;
            if (category1.Type > category2.Type)
            {
                winnerPlayer = players[0].Name;
                winnerCategory = category1.Name;
                winnerOutput = category1.Output;
                // return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";
            }
            else
            {
                winnerPlayer = players[1].Name;
                winnerCategory = category2.Name;
                winnerOutput = category2.Output;
                // return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";
            }

            return $"{winnerPlayer} wins. - with {winnerCategory}: {winnerOutput}";

        }
        else
        {
            var highCardComparer = new HighCardComparer();
            var compareResult = highCardComparer.Compare(pokerHands1, pokerHands2);
            if (compareResult != 0)
            {
                var winnerPlayerName = compareResult < 0 ? players[1].Name : players[0].Name;
                var winnerOutput = highCardComparer.WinnerOutput;
                var winnerCategory = highCardComparer.CategoryName;
                return $"{winnerPlayerName} wins. - with {winnerCategory}: {winnerOutput}";
            }
        }

        return "Tie.";
    }

    private static Category GetCategory(IOrderedEnumerable<Card> pokerHands)
    {
        var pairs = pokerHands
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