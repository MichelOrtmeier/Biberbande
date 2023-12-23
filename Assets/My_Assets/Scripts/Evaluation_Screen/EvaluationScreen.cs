using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationScreen : MonoBehaviour
{
    [SerializeField] Button goToHomeMenuButton;
    [SerializeField] Button restartGameButton;
    [SerializeField] GameObject panelToAttachPlayerScoresTo;
    [SerializeField] GameObject playerScorePrefab;

    DeckOfCards deckOfCards;

    private void Awake()
    {
        deckOfCards = FindObjectOfType<DeckOfCards>();
    }

    private void Start()
    {
        
    }
}
