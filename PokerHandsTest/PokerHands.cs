using System.Collections;
using PokerHands.Categories;
using PokerHandsTest.Categories;

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
        var pairs  = GetPairs();
        
        if (pairs.Count() == 2)
        {
            var biggerPair = pairs.First().First().Output;
            var smallerPair = pairs.Last().First().Output;
            return new TwoPairs
            {
                Output = $"{biggerPair} over {smallerPair}"
            };
        }
        if (pairs.Any())
        {
            return new Pair { Output = pairs.First().First().Output };
        }

        return new HighCard();
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

public class TwoPairs : Category
{
    public override CategoryType Type => CategoryType.TwoPairs;
    public override string Name => "two pairs";
}