using PokerHandsTest.Categories;

namespace PokerHands.Categories;

internal class HighCard : Category
{
    public override CategoryType Type => CategoryType.HighCard;
    public override string Name => "high card";
}