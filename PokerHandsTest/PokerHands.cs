using System.Collections;
using PokerHands.Categories;

namespace PokerHands;

public class PokerHands : IEnumerable<Card>
{
    private readonly IEnumerable<Card> _cards;

    public PokerHands(IEnumerable<Card> cards)
    {
        _cards = cards;
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
        return DecidedCategory();
    }

    private Category DecidedCategory()
    {
        if (isMatchedTwoPairs(this))
        {
            var biggerPair = GetPairs().First().First().Output;
            var smallerPair = GetPairs().Last().First().Output;
            return new TwoPairs
            {
                Output = $"{biggerPair} over {smallerPair}"
            };
        }
        else
        {
            return NextMatch();
        }
    }

    private Category NextMatch()
    {
        if (isMatchedPair(this))
        {
            return new Pair { Output = GetPairs().First().First().Output };
        }
        else
        {
            return new HighCard();
        }
    }

    private static bool isMatchedPair(PokerHands pokerHands)
    {
        return pokerHands.GetPairs().Any();
    }

    private static bool isMatchedTwoPairs(PokerHands pokerHands)
    {
        return pokerHands.GetPairs().Count() == 2;
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