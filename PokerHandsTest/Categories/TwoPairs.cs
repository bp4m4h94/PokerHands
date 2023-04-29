using PokerHandsTest.Categories;

namespace PokerHands.Categories;

public class TwoPairs : Category
{
    public override CategoryType Type => CategoryType.TwoPairs;
    public override string Name => "two pairs";
}