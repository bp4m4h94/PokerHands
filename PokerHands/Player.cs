namespace PokerHands;

public class Player
{
    public string Name { get; set; }
    public List<Card> Card { get; set; }

    public IOrderedEnumerable<Card> GetPokerHands()
    {
        return Card.OrderByDescending(x => x.Value);
    }
}