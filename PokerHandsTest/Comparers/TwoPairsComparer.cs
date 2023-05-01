namespace PokerHands.Comparers;

internal class TwoPairsComparer : SameCategoryComparer
{
    public override int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
    {
        // "Black: 2H 2S TC TD KH  White: 3S 3S QS QS AS"
        // {T,T}{2,2}K     {Q,Q}{3,3}A
        // T2K Q3A
        return CompareCardsByValue(pokerHands1.GetFirstCardOfEachGroup(), pokerHands2.GetFirstCardOfEachGroup());
    }

    public override string WinnerCategory => "two pairs";
}