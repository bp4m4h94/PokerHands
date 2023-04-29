using PokerHands.Categories;

namespace PokerHands.CategoryMatcher;

public class PairedMatcher
{
    public Category NextMatch(PokerHands pokerHands)
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

public class TwoPairsMatcher
{
    private readonly PairedMatcher _pairedMatcher = new PairedMatcher();

    public Category DecidedCategory(PokerHands pokerHands)
    {
        if (IsMatched(pokerHands))
        {
            return GetMatchedCategory(pokerHands);
        }
        else
        {
            return _pairedMatcher.NextMatch(pokerHands);
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