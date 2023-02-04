namespace PokerHands.Comparers;

public interface IPokerHandsComparer
{
    int Compare(PokerHands pokerHands1, PokerHands pokerHands2);
    string WinnerOutput { get; }
    string WinnerCategory { get; }
}