using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EvaluationScreen : MonoBehaviour
{
    [SerializeField] GameObject panelToAttachPlayerScoresTo;
    [SerializeField] GameObject playerScorePrefab;

    Player[] players;

    private void Start()
    {
        InitPlayerScoreVisualisations();
    }

    private void InitPlayerScoreVisualisations()
    {
        players = FindObjectOfType<DeckOfCards>().Players.OrderBy(player => player.GetScore()).ToArray();
        foreach (Player player in players)
        {
            InitPlayerScoreVisualisation(player);
        }
    }

    private void InitPlayerScoreVisualisation(Player player)
    {
        GameObject score = Instantiate(playerScorePrefab, panelToAttachPlayerScoresTo.transform);
        InitScoreText(player, score);
        InitPlayerHand(player, score);
    }

    private static void InitPlayerHand(Player player, GameObject score)
    {
        CardVisualisation[] hand = score.GetComponentsInChildren<CardVisualisation>();
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i].Value = player.GetCard(i);
            hand[i].ShowValue();
        }
    }

    private static void InitScoreText(Player player, GameObject score)
    {
        TextMeshProUGUI scoreText = score.GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text = $"{player.Name} - {player.GetScore()}";
    }

    public void OnGoToHomeMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
