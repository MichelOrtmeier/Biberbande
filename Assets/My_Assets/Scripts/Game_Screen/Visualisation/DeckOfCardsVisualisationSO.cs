using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.InputSystem.DualShock;

[CreateAssetMenu(menuName = "DeckOfCardsVisualisation", fileName = "DeckOfCardsVisualisation")]
public class DeckOfCardsVisualisationSO : ScriptableObject
{
    public Sprite CardBack { get => cardBack; }

    [SerializeField] List<CardVisualisationInput> cardVisualisationsInput = new();

    [SerializeField] Sprite cardBack;

    [Serializable]
    class CardVisualisationInput
    {
        public Card cardType;
        public Sprite visualisation;
    }

    Dictionary<Card, Sprite> cardVisualisationsLookup = new();

    private void OnEnable()
    {
        InitVisualisationsLookup();
    }
    private void InitVisualisationsLookup()
    {
        foreach (CardVisualisationInput visualisation in cardVisualisationsInput)
        {
            cardVisualisationsLookup.Add(visualisation.cardType, visualisation.visualisation);
        }
    }

    public Sprite GetCardVisualisation(Card card)
    {
        if (cardVisualisationsLookup.ContainsKey(card))
        {
            return cardVisualisationsLookup[card];
        }
        else
        {
            throw new KeyNotFoundException($"The visualisation of the card {card} could not be found.");
        }
    }
}
