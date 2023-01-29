namespace PokerHands.Categories;

internal abstract class Category
{
    public abstract CategoryType Type { get; }

    public abstract string Name { get; }

    public string Output { get; set; }
}