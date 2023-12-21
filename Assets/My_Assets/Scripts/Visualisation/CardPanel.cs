using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.UI;

public class CardPanel : MonoBehaviour
{
    [SerializeField] CardVisualisation[] cardsVisualisation = new CardVisualisation[4];
    [SerializeField] CardVisualisation discardPileVisualisation;
    [SerializeField] CardVisualisation drawPileVisualisation;

    CardPiles piles = new CardPiles();

    private void Start()
    {
        foreach(var card in cardsVisualisation)
        {
            card.Value = piles.PopFromDraw();
        }
        discardPileVisualisation.Value = piles.PopFromDraw();
    }

    public void OnCardClick(int card)
    {
        cardsVisualisation[card].Flip();
    }

    public void OnDiscardPileClick()
    {
        
    }

    public void OnDrawPileClick()
    {

    }
}
//namespace Assets.My_Assets
//{
//    internal class Cards : Stack<CardType>
//    {
//        public Cards()
//        {
//            int count;
//            List<CardType> cards = new List<CardType>();
//            foreach(CardType type in Enumerable.Range(0, 10))
//            {
//                if((int)type == 9)
//                {
//                    count = 9;
//                }
//                else
//                {
//                    count = 4;
//                }
//            }
//        }

//    }
//}
