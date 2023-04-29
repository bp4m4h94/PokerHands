using PokerHands.Categories;

namespace PokerHands.CategoryMatcher;

public abstract class CategoryMatcher
{
    private readonly PairedMatcher _nextCategoryMatcher;

    protected CategoryMatcher(PairedMatcher nextCategoryMatcher)
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

    protected abstract Category GetMatchedCategory(PokerHands pokerHands);
    protected abstract bool IsMatched(PokerHands pokerHands);
}

public class TwoPairsMatcher : CategoryMatcher
{
    public TwoPairsMatcher(PairedMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
    {
    }

    protected override Category GetMatchedCategory(PokerHands pokerHands)
    {
        var biggerPair = pokerHands.GetPairs().First().First().Output;
        var smallerPair = pokerHands.GetPairs().Last().First().Output;
        return new TwoPairs
        {
            Output = $"{biggerPair} over {smallerPair}"
        };
    }

    protected override bool IsMatched(PokerHands pokerHands)
    {
        return pokerHands.GetPairs().Count() == 2;
    }
}