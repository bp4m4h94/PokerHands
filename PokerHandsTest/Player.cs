using System.Collections;
using PokerHands.Categories;

namespace PokerHands;

public class Player
{
    public string Name { get; set; }
    public List<Card> Card { get; set; }

    public PokerHands GetPokerHands()
    {
        return new PokerHands(Card.OrderByDescending(x => x.Value));
    }
}

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
        var pairs  = this.GroupBy(x => x.Value)
            .Where(x => x.Count() == 2);
        var isPair = pairs.Any();
        if (isPair)
        {
            return new Pair { Output = pairs.First().First().Output };
        }

        return new HighCard();
    }
}