using PokerHands.Categories;

namespace PokerHands.CategoryMatcher;

public class TwoPairsMatcher
{
    private readonly PairedMatcher _nextCategoryMatcher;

    public TwoPairsMatcher(PairedMatcher nextCategoryMatcher)
    {
        _nextCategoryMatcher = nextCategoryMatcher;
    }

    public Category DecidedCategory(PokerHands pokerHands)
    {
        if (IsMatched(pokerHands))
        {
            return GetMatchedCategory(pokerHands);
        }
        else
        {
            return _nextCategoryMatcher.DecidedCategory(pokerHands);
        }
    }

    private Category GetMatchedCategory(PokerHands pokerHands)
    {
        var biggerPair = pokerHands.GetPairs().First().First().Output;
        var smallerPair = pokerHands.GetPairs().Last().First().Output;
        return new TwoPairs
        {
            Output = $"{biggerPair} over {smallerPair}"
        };
    }

    private bool IsMatched(PokerHands pokerHands)
    {
        return pokerHands.GetPairs().Count() == 2;
    }
}