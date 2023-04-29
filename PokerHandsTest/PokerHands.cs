using System.Collections;
using PokerHands.Categories;

namespace PokerHands;

public class TwoPairsMatcher
{
    private PokerHands _pokerHands;

    public TwoPairsMatcher(PokerHands pokerHands)
    {
        _pokerHands = pokerHands;
    }

    public Category DecidedCategory()
    {
        if (IsMatchedTwoPairs(_pokerHands))
        {
            var biggerPair = _pokerHands.GetPairs().First().First().Output;
            var smallerPair = _pokerHands.GetPairs().Last().First().Output;
            return new TwoPairs
            {
                Output = $"{biggerPair} over {smallerPair}"
            };
        }
        else
        {
            return NextMatch(_pokerHands);
        }
    }

    private Category NextMatch(PokerHands pokerHands)
    {
        if (IsMatchedPair(pokerHands))
        {
            return new Pair { Output = _pokerHands.GetPairs().First().First().Output };
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

    private static bool IsMatchedTwoPairs(PokerHands pokerHands)
    {
        return pokerHands.GetPairs().Count() == 2;
    }
}

public class PokerHands : IEnumerable<Card>
{
    private readonly IEnumerable<Card> _cards;
    private readonly TwoPairsMatcher _twoPairsMatcher;

    public PokerHands(IEnumerable<Card> cards)
    {
        _cards = cards;
        _twoPairsMatcher = new TwoPairsMatcher(this);
    }

    public TwoPairsMatcher TwoPairsMatcher
    {
        get { return _twoPairsMatcher; }
    }

    public IEnumerator<Card> GetEnumerator()
    {
        return _cards.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Category GetCategory()
    {
        return TwoPairsMatcher.DecidedCategory();
    }

    public IEnumerable<IGrouping<int, Card>> GetPairs()
    {   
        return this.GroupBy(x => x.Value)
            .Where(x => x.Count() == 2);
    }

    public IEnumerable<Card> GetFirstCardOfEachGroup()
    {
        return this.GroupBy(x => x.Value)
            .OrderByDescending(x => x.Count())
            .Select(x => x.First());
    }
}