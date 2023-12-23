using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CardPiles
{
    Stack<Card> drawPile = new Stack<Card>();
    Stack<Card> discardPile = new Stack<Card>();

    public CardPiles()
    {
        InitDrawPile();
        PushToDiscard(PopFromDraw());
    }

    private void InitDrawPile()
    {
        foreach (Card type in GetCardTypes())
        {
            AddCardsToDraw(type);
        }
        drawPile = new Stack<Card>(drawPile.Shuffle());
    }

    private void AddCardsToDraw(Card type)
    {
        for (int i = 0; i < GetAmountInCardDeck(type); i++)
        {
            drawPile.Push(type);
        }
    }

    private static IEnumerable<int> GetCardTypes()
    {
        return Enumerable.Range(0, Enum.GetValues(typeof(Card)).Length - 1);
    }

    private static int GetAmountInCardDeck(Card card)
    {
        int amount;
        if (card != Card.nine)
        {
            amount = 4;
        }
        else
        {
            amount = 9;
        }
        return amount;
    }

    public Card PopFromDraw()
    {
        RefillDrawPile();
        return drawPile.Pop();
    }

    private void RefillDrawPile()
    {
        if (drawPile.Count == 0)
        {
        Card discardTop = PopFromDiscard();
        drawPile = new Stack<Card>(drawPile.Concat(discardPile));
        drawPile = new Stack<Card>(drawPile.Shuffle());
        discardPile.Clear();
        discardPile.Push(discardTop);
        }
    }

    public Card PeekFromDraw()
    {
        RefillDrawPile();
        return drawPile.Peek();
    }

    public Card PopFromDiscard()
    {
        return discardPile.Pop();
    }

    public Card PeekFromDiscard()
    {
        return discardPile.Peek();
    }

    public void PushToDiscard(Card card)
    {
        discardPile.Push(card);
    }

    public void DiscardDrawPileTop()
    {
        PushToDiscard(PopFromDraw());
    }
}