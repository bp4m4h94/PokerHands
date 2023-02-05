namespace PokerHands.Comparers;

internal class PairComparer: IPokerHandsComparer
{
    public int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
    {
        var pair1 = pokerHands1.GroupBy(x =>　x.Value)
            .Where(x => x.Count() == 2);
        var pair2 = pokerHands2.GroupBy(x => x.Value)
            .Where(x => x.Count() == 2);
        var compareResult = pair1.First().First().Value - pair2.First().First().Value;
        WinnerOutput = compareResult > 0 ? pair1.First().First().Output : pair2.First().First().Output;
        return compareResult;
    }

    public string WinnerOutput { get; private set; }

    public string WinnerCategory => "pair";
}