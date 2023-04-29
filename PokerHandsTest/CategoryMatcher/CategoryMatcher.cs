﻿using PokerHands.Categories;

namespace PokerHands.CategoryMatcher;

public abstract class CategoryMatcher
{
    private readonly CategoryMatcher _nextCategoryMatcher;

    protected CategoryMatcher(CategoryMatcher nextCategoryMatcher)
    {
        _nextCategoryMatcher = nextCategoryMatcher;
    }

    public Category DecidedCategory(PokerHands pokerHands)
    {
        if (IsMatched(pokerHands))
        {
            return GetMatchedCategory(pokerHands);
        }
        else
        {
            var decidedCategory = _nextCategoryMatcher != null 
                ? _nextCategoryMatcher.DecidedCategory(pokerHands) 
                : new HighCard();
            return decidedCategory;
        }
    }

    protected abstract Category GetMatchedCategory(PokerHands pokerHands);
    protected abstract bool IsMatched(PokerHands pokerHands);
}