namespace PokerHands.Comparers;

public class HighCardComparer : IPokerHandsComparer
{
    public int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
    {
        var compareResult = CompareCardsByValue(pokerHands1, pokerHands2);

        return compareResult;
    }

    public int CompareCardsByValue(IEnumerable<Card> pokerHands1, IEnumerable<Card> pokerHands2)
    {
        using var enumerator1 = pokerHands1.GetEnumerator();
        using var enumerator2 = pokerHands2.GetEnumerator();
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
    public string WinnerCategory => "high card";
}