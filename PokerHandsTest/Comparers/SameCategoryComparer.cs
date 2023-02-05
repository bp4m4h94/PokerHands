namespace PokerHands.Comparers;

public abstract class SameCategoryComparer : IPokerHandsComparer
{
    public abstract int Compare(PokerHands pokerHands1, PokerHands pokerHands2);

    protected int CompareCardsByValue(IEnumerable<Card> cards1, IEnumerable<Card> cards2)
    {
        using var enumerator1 = cards1.GetEnumerator();
        using var enumerator2 = cards2.GetEnumerator();
        var compareResult = 0;
        while (enumerator1.MoveNext() && enumerator2.MoveNext())
        {
            var card1 = enumerator1.Current;
            var card2 = enumerator2.Current;

            compareResult = card1.Value - card2.Value;
            if (compareResult != 0)
            {
                WinnerOutput = compareResult < 0 ? card2.Output : card1.Output;
                break;
            }
        }

        return compareResult;
    }

    public string WinnerOutput { get; private set; }
    public abstract string WinnerCategory { get; }
}