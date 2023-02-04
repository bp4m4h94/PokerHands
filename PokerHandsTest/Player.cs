using System.Collections;

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
}