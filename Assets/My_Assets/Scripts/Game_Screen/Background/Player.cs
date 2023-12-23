using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//mehr Methoden, stärkere Eigenständigkeit?
public class Player
{
    public string Name { get; private set; }
    private Card[] hand;

    public Player(string name)
    {
        Name = name;
        hand = new Card[4];
    }

    public Card GetCard(int index)
    {
        if (index < 0 || index >= hand.Length)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        return hand[index];
    }

    public void SetCard(Card card, int index)
    {
        if (index < 0 || index >= hand.Length)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        hand[index] = card;
    }

    public int GetScore()
    {
        int score = 0;
        foreach(Card card in hand)
        {
            score += (int)card;
        }
        return score;
    }
}
