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