using PokerHands.Categories;

namespace PokerHands.CategoryMatcher;

public class PairedMatcher
{
    public Category DecidedCategory(PokerHands pokerHands)
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

    private bool IsMatchedPair(PokerHands pokerHands)
    {
        return pokerHands.GetPairs().Any();
    }
}