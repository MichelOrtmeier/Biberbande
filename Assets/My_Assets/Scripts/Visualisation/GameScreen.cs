using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.UI;
using System.Data;
using System;
using TMPro;

public delegate void CardModifier(CardVisualisation card);

public class GameScreen : MonoBehaviour
{
    #region variables
    [Header("Cards")]
    [SerializeField] CardVisualisation[] playerHandCardVisualisations = new CardVisualisation[4];
    [SerializeField] CardVisualisation discardPileVisualisation;
    [SerializeField] CardVisualisation drawPileVisualisation;
    [SerializeField] TextMeshProUGUI playerNameVisualisation;

    [Header("Modifications")]
    [SerializeField] float secondsToShowCompletedSwapTransaction = 3f;

    DeckOfCards deckOfCards;
    CardPile pileToSwapWith = CardPile.None;
    #endregion

    private void Start()
    {
        deckOfCards = new DeckOfCards(new string[]
        {
            "Jörg",
            "Danika",
            "Michel",
        });
        ResetVisualisationToMoveStart();
    }

    public void OnCardClick(int card)
    {
        CardVisualisation playerHandCardVisualisation = playerHandCardVisualisations[card];
        CardVisualisation pileToSwapWithVisualisation;
        if(pileToSwapWith == CardPile.DrawPile)
        {
            deckOfCards.SwapDrawPileTopForCard(card);
            pileToSwapWithVisualisation = drawPileVisualisation;
        }
        else if(pileToSwapWith == CardPile.DiscardPile)
        {
            deckOfCards.SwapDiscardTopForCard(card);
            pileToSwapWithVisualisation = discardPileVisualisation;
        }
        else
        {
            throw new Exception("The click on a playerHandCard could not be processed.");
        }
        StartCoroutine(ShowSwap(playerHandCardVisualisation, pileToSwapWithVisualisation));
    }

    private IEnumerator ShowSwap(CardVisualisation playerHandCardVisualisation, CardVisualisation pileToSwapWithVisualisation)
    {
        ModifyAllCardVisualisations((card) => card.DisableButton());
        playerHandCardVisualisation.ShowValue();
        playerHandCardVisualisation.Highlight();
        pileToSwapWithVisualisation.Highlight();
        yield return new WaitForSecondsRealtime(secondsToShowCompletedSwapTransaction);
        pileToSwapWithVisualisation.ShowBack();
        pileToSwapWithVisualisation.StopHighlight();
        discardPileVisualisation.Highlight();
        UpdateCardVisualisationValues();
        yield return new WaitForSeconds(secondsToShowCompletedSwapTransaction);
        playerHandCardVisualisation.ShowBack();
        OnMoveFinished();
    }

    #region DiscardPile
    public void OnDiscardPileClick()
    {
        if(pileToSwapWith == CardPile.None)
        {
            OnInitialDiscardPileSelection();
        }
        else if(pileToSwapWith == CardPile.DrawPile)
        {
            OnDiscardDrawPileTop();
        }
    }
    private void OnInitialDiscardPileSelection()
    {
        pileToSwapWith = CardPile.DiscardPile;
        discardPileVisualisation.Highlight();
        ModifyAllPileVisualisations((card) => card.DisableButton());
        ModifyAllPlayerHandVisualisations((card) => card.EnableButton());
    }

    private void OnDiscardDrawPileTop()
    {
        deckOfCards.DiscardDrawPileTop();
        StartCoroutine(ShowDiscardDrawPileTop());
    }

    private IEnumerator ShowDiscardDrawPileTop()
    {
        drawPileVisualisation.Highlight();
        discardPileVisualisation.Highlight();
        yield return new WaitForSecondsRealtime(secondsToShowCompletedSwapTransaction);
        drawPileVisualisation.ShowBack();
        OnMoveFinished();
    }

    #endregion

    #region DrawPile
    public void OnDrawPileClick()
    {
        if(pileToSwapWith == CardPile.None)
        {
            OnInitialDrawPileSelection();
        }
    }

    private void OnInitialDrawPileSelection()
    {
        pileToSwapWith = CardPile.DrawPile;
        drawPileVisualisation.ShowValue();
        drawPileVisualisation.Highlight();
        drawPileVisualisation.DisableButton();
        discardPileVisualisation.EnableButton();
        ModifyAllPlayerHandVisualisations((card) => card.EnableButton());
    }
    #endregion DrawPile


    #region general
    private void OnMoveFinished()
    {
        deckOfCards.MoveOnToNextPlayer();
        pileToSwapWith = CardPile.None;
        ResetVisualisationToMoveStart();
    }

    private void ResetVisualisationToMoveStart()
    {
        UpdateCardVisualisationValues();
        ModifyAllPileVisualisations((pile) => pile.EnableButton());
        ModifyAllPlayerHandVisualisations((card) => card.DisableButton());
        ModifyAllCardVisualisations((card) => card.StopHighlight());
        playerNameVisualisation.text = "Du bist dran,\n" + deckOfCards.GetPlayerName();
    }

    private void UpdateCardVisualisationValues()
    {
        for(int i = 0; i < playerHandCardVisualisations.Length; i++)
        {
            playerHandCardVisualisations[i].Value = deckOfCards.GetCard(i);
        }
        discardPileVisualisation.Value = deckOfCards.PeekFromDiscardPile();
        drawPileVisualisation.Value = deckOfCards.PeekFromDrawPile();
    }

    private void ModifyAllCardVisualisations(CardModifier cardModifier)
    {
        ModifyAllPileVisualisations(cardModifier);
        ModifyAllPlayerHandVisualisations(cardModifier);
    }

    private void ModifyAllPlayerHandVisualisations(CardModifier cardModifier)
    {
        foreach (CardVisualisation card in playerHandCardVisualisations)
        {
            cardModifier(card);
        }
    }

    private void ModifyAllPileVisualisations(CardModifier cardModifier)
    {
        cardModifier(drawPileVisualisation);
        cardModifier(discardPileVisualisation);
    }
    #endregion
}
