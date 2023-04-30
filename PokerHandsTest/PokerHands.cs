using System.Collections;
using PokerHands.Categories;
using PokerHands.CategoryMatcher;

namespace PokerHands;

public class PokerHands : IEnumerable<Card>
{
    private readonly IEnumerable<Card> _cards;
    private readonly CategoryMatcher.CategoryMatcher _categoryMatcher;

    public PokerHands(IEnumerable<Card> cards)
    {
        _cards = cards;
        _categoryMatcher = new TwoPairsMatcher(
            new PairedMatcher(null));
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
        return _categoryMatcher.DecidedCategory(this);
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

    public bool IsTowPairs()
    {
        return GetPairs().Count() == 2;
    }
}