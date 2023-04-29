using PokerHands.Categories;

namespace PokerHands.CategoryMatcher;

public class TwoPairsMatcher : CategoryMatcher
{
    public TwoPairsMatcher(CategoryMatcher? nextCategoryMatcher) : base(nextCategoryMatcher)
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