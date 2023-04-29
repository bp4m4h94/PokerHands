using PokerHands.Categories;

namespace PokerHands.CategoryMatcher;

public class PairedMatcher: CategoryMatcher
{
    public PairedMatcher(CategoryMatcher? nextCategoryMatcher) : base(nextCategoryMatcher)
    {
    }

    protected override Category GetMatchedCategory(PokerHands pokerHands)
    {
        return new Pair { Output = pokerHands.GetPairs().First().First().Output };
    }

    protected override bool IsMatched(PokerHands pokerHands)
    {
        return pokerHands.GetPairs().Any();
    }
}