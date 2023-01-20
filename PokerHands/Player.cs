namespace PokerHands;

public class Player
{
    public string Name { get; set; }
    public List<Card> Card { get; set; }
}

public class Card
{
    public string Suit { get; set; }
    public int Value { get; set; }
    public string Output { get; set; }
}