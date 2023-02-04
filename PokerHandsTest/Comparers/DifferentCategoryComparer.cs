using PokerHands.Categories;

namespace PokerHands.Comparers;

public class PokerHandsComparer : IPokerHandsComparer
{
    public int Compare(PokerHands pokerHands1, PokerHands pokerHands2)
    {
        var category1 = pokerHands1.GetCategory();
        var category2 = pokerHands2.GetCategory();
        var compareResult = category1.Type - category2.Type;
        
        WinnerCategory = compareResult > 0 ? category1.Name : category2.Name;
        WinnerOutput = compareResult > 0 ? category1.Output : category2.Output;

        return compareResult;
    }

    public string WinnerOutput { get; private set; }

    public string WinnerCategory { get; private set; }
}