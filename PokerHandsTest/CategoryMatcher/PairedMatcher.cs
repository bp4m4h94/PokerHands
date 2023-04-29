using PokerHands.Categories;

namespace PokerHands.CategoryMatcher;

public class PairedMatcher: CategoryMatcher
{
    public PairedMatcher(CategoryMatcher nextCategoryMatcher) : base(nextCategoryMatcher)
    {
    }

    // public Category DecidedCategory(PokerHands pokerHands)
    // {
    //     if (IsMatchedPair(pokerHands))
    //     {
    //         return new Pair { Output = pokerHands.GetPairs().First().First().Output };
    //     }
    //     else
    //     {
    //         return new HighCard();
    //     }
    // }

    protected override Category GetMatchedCategory(PokerHands pokerHands)
    {
        return new Pair { Output = pokerHands.GetPairs().First().First().Output };
    }

    protected override bool IsMatched(PokerHands pokerHands)
    {
        return IsMatchedPair(pokerHands);
    }

    private bool IsMatchedPair(PokerHands pokerHands)
    {
        return pokerHands.GetPairs().Any();
    }
}