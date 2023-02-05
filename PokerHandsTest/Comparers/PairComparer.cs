namespace PokerHands.Comparers;

internal class PairComparer: SameCategoryComparer
{
    public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
    {
        // Black: 2S 8S KS QS QS  White: 3H QS QC AD 5H
        // {QQ}{K}{8}{2}  {QQ}{A}{5}{3}
        // QK82 QA53
        return CompareCardsByValue(pokerHands1.GetFirstCardOfEachGroup(), pokerHands2.GetFirstCardOfEachGroup());
    }

    public override string WinnerCategory => "pair";
}