namespace PokerHands.Comparers;

internal class PairComparer: SameCategoryComparer
{
    public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
    {
        // Black: 2S 8S KS QS QS  White: 3H QS QC AD 5H
        // {QQ}{K}{8}{2}  {QQ}{A}{5}{3}
        // QK82 QA53
        var firstCardOfEachGroup1 = pokerHands1.GetFirstCardOfEachGroup();
        var firstCardOfEachGroup2 = pokerHands2.GetFirstCardOfEachGroup();

        // var highCardComparer = new HighCardComparer();
        var compareResult = CompareCardsByValue(firstCardOfEachGroup1, firstCardOfEachGroup2);
        // WinnerOutput = highCardComparer.WinnerOutput;
        return compareResult;
    }

    public override string WinnerCategory => "pair";
}