using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardClickInterpreter : MonoBehaviour
{
    protected DeckOfCards deckOfCards;
    protected GameScreen gameScreen;
    protected CardClickInterpreterFactory interpreterFactory;

    private void Start()
    {
        deckOfCards = FindObjectOfType<DeckOfCards>();
        gameScreen = FindObjectOfType<GameScreen>();
        interpreterFactory = FindObjectOfType<CardClickInterpreterFactory>();
    }

    public abstract void OnCardClick(int card);

    public abstract void OnDiscardPileClick();

    public abstract void OnDrawPileClick();
}
