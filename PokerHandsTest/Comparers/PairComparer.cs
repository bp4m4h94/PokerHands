namespace PokerHands.Comparers;

internal class PairComparer: IPokerHandsComparer
{
    public string WinnerOutput { get; private set; }

    public int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
    {
        // Black: 2S 8S KS QS QS  White: 3H QS QC AD 5H
        // {QQ}{K}{8}{2}  {QQ}{A}{5}{3}
        // QK82 QA53
        var firstCardOfEachGroup1 = GetFirstCardOfEachGroup(pokerHands1);
        var firstCardOfEachGroup2 = GetFirstCardOfEachGroup(pokerHands2);

        var highCardComparer = new HighCardComparer();
        var compareResult = highCardComparer.CompareCardsByValue(firstCardOfEachGroup1, firstCardOfEachGroup2);
        WinnerOutput = highCardComparer.WinnerOutput;
        return compareResult;
    }

    private static IEnumerable<Card> GetFirstCardOfEachGroup(PokerHands pokerHands)
    {
        return pokerHands.GroupBy(x => x.Value)
            .OrderByDescending(x => x.Count())
            .Select(x => x.First());
    }

    public string WinnerCategory => "pair";
}