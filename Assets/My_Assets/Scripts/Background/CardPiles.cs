using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CardPiles
{
    Stack<CardType> drawPile = new Stack<CardType>();
    Stack<CardType> discardPile = new Stack<CardType>();

    public CardPiles()
    {
        InitDrawPile();
    }

    private void InitDrawPile()
    {
        foreach (CardType type in GetCardTypes())
        {
            AddCardsToDraw(type);
        }
        drawPile = new Stack<CardType>(drawPile.Shuffle());
    }

    private void AddCardsToDraw(CardType type)
    {
        for (int i = 0; i < GetAmountInCardDeck(type); i++)
        {
            drawPile.Push(type);
        }
    }

    private static IEnumerable<int> GetCardTypes()
    {
        return Enumerable.Range(0, Enum.GetValues(typeof(CardType)).Length - 1);
    }

    private static int GetAmountInCardDeck(CardType card)
    {
        int amount;
        if (card != CardType.nine)
        {
            amount = 4;
        }
        else
        {
            amount = 9;
        }
        return amount;
    }

    public CardType PopFromDraw()
    {
        RefillDrawPile();
        return drawPile.Pop();
    }

    private void RefillDrawPile()
    {
        if (drawPile.Count == 0)
        {
        CardType discardTop = PopFromDiscard();
        drawPile = new Stack<CardType>(drawPile.Concat(discardPile));
        drawPile = new Stack<CardType>(drawPile.Shuffle());
        discardPile.Clear();
        discardPile.Push(discardTop);
        }
    }

    public CardType PeekFromDraw()
    {
        RefillDrawPile();
        return drawPile.Peek();
    }

    public CardType PopFromDiscard()
    {
        return discardPile.Pop();
    }

    public CardType PeekFromDiscard()
    {
        return discardPile.Peek();
    }

    public void PushToDiscard(CardType card)
    {
        discardPile.Push(card);
    }

    public void SwapDrawPileTopForDiscardPileTop()
    {
        PushToDiscard(PopFromDraw());
    }
}