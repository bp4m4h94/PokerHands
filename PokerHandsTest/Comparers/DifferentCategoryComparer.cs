using PokerHands.Categories;

namespace PokerHands.Comparers;

public class DifferentCategoryComparer
{
    public int Compare(Category category1, Category category2)
    {
        var compareResult = category1.Type - category2.Type;
        if (category1.Type > category2.Type)
        {
            WinnerCategory = category1.Name;
            WinnerOutput = category1.Output;
        }
        else
        {
            WinnerCategory = category2.Name;
            WinnerOutput = category2.Output;
        }

        return compareResult;
    }

    public string WinnerOutput { get; private set; }

    public string WinnerCategory { get; private set; }
}