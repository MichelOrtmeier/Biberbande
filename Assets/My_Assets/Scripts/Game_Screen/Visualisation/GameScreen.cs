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
    //StateDuringPlayerMove stateDuringPlayerMove = StateDuringPlayerMove.StartedMove;
    #endregion

    private void Start()
    {
        deckOfCards = FindObjectOfType<DeckOfCards>();
        deckOfCards.InitPlayers(new string[] { "Danika", "Jörg", "Michel" });
        ResetVisualisationToMoveStart();
    }

    public void OnCardClick(int card)
    {
        UpdateCardVisualisationValues();
        FindObjectOfType<CardClickInterpreter>().OnCardClick(card);
    }

    public void OnDrawPileClick()
    {
        UpdateCardVisualisationValues();
        FindObjectOfType<CardClickInterpreter>().OnDrawPileClick();
    }

    public void OnDiscardPileClick()
    {
        UpdateCardVisualisationValues();
        FindObjectOfType<CardClickInterpreter>().OnDiscardPileClick();
    }

    public void ShowInitialDiscardPileSelection()
    {
        discardPileVisualisation.Highlight();
        ModifyAllPileVisualisations((card) => card.DisableButton());
        ModifyAllPlayerHandVisualisations((card) => card.EnableButton());
    }

    public void ShowInitialDrawPileSelection()
    {
        drawPileVisualisation.ShowValue();
        drawPileVisualisation.Highlight();
        drawPileVisualisation.DisableButton();
        discardPileVisualisation.EnableButton();
        ModifyAllPlayerHandVisualisations((card) => card.EnableButton());
    }

    public void ShowSwapDiscardPileTopForCard(int card)
    {
        StartCoroutine(StartShowSwapPileTopForPlayerHand(playerHandCardVisualisations[card], discardPileVisualisation));
    }

    public void ShowSwapDrawPileTopForCard(int card)
    {
        StartCoroutine(StartShowSwapPileTopForPlayerHand(playerHandCardVisualisations[card], drawPileVisualisation));
    }

    private IEnumerator StartShowSwapPileTopForPlayerHand(CardVisualisation playerHandCardVisualisation, CardVisualisation pileToSwapWithVisualisation)
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
        ResetVisualisationToMoveStart();
    }

    public void ShowSwapDrawPileTopForDiscardPileTop()
    {
        StartCoroutine(StartShowSwapDrawPileTopForDiscardPileTop());
    }

    private IEnumerator StartShowSwapDrawPileTopForDiscardPileTop()
    {
        drawPileVisualisation.Highlight();
        discardPileVisualisation.Highlight();
        yield return new WaitForSecondsRealtime(secondsToShowCompletedSwapTransaction);
        drawPileVisualisation.ShowBack();
        ResetVisualisationToMoveStart();
    }

    public void ShowReceivedMagnifier()
    {
        drawPileVisualisation.ShowValue();
        drawPileVisualisation.Highlight();
        ModifyAllPileVisualisations(pile => pile.DisableButton());
        ModifyAllPlayerHandVisualisations(card => card.EnableButton());
    }

    public void ShowUseMagnifierFor(int card)
    {
        playerHandCardVisualisations[card].ShowValue();
    }

    public void ShowUsedMagnifier()
    {
        ModifyAllPlayerHandVisualisations((card) => { card.ShowBack(); card.DisableButton(); });
        ModifyAllPileVisualisations((pile) => pile.EnableButton());
        drawPileVisualisation.StopHighlight();
        drawPileVisualisation.ShowBack();
        UpdateCardVisualisationValues();
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
}
