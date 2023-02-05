using PokerHandsTest.Categories;

namespace PokerHands.Categories;

internal class Pair : Category
{
    public override CategoryType Type => CategoryType.Pair;
    public override string Name => "pair";
}