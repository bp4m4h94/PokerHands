using PokerHands.Categories;

namespace PokerHands.CategoryMatcher;

public class TwoPairsMatcher
{
    public Category DecidedCategory(PokerHands pokerHands)
    {
        if (IsMatched(pokerHands))
        {
            return GetMatchedCategory(pokerHands);
        }
        else
        {
            return NextMatch(pokerHands);
        }
    }

    private static Category GetMatchedCategory(PokerHands pokerHands)
    {
        var biggerPair = pokerHands.GetPairs().First().First().Output;
        var smallerPair = pokerHands.GetPairs().Last().First().Output;
        return new TwoPairs
        {
            Output = $"{biggerPair} over {smallerPair}"
        };
    }

    private static Category NextMatch(PokerHands pokerHands)
    {
        if (IsMatchedPair(pokerHands))
        {
            return new Pair { Output = pokerHands.GetPairs().First().First().Output };
        }
        else
        {
            return new HighCard();
        }
    }

    private static bool IsMatchedPair(PokerHands pokerHands)
    {
        return pokerHands.GetPairs().Any();
    }

    private static bool IsMatched(PokerHands pokerHands)
    {
        return pokerHands.GetPairs().Count() == 2;
    }
}