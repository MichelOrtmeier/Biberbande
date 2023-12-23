using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] Button startButton;
    [Header("Player Amount")]
    [SerializeField] TextMeshProUGUI playerAmountText;
    [SerializeField] Button addPlayerButton;
    [SerializeField] Button removePlayerButton;
    [Range(2, 6)]
    [SerializeField] int defaultPlayerAmount;
    [SerializeField] string[] playerNames = new string[6];

    int playerAmount;
    DeckOfCards deckOfCards;
    const int minPlayerAmount = 2;
    const int maxPlayerAmount = 6;

    private void Start()
    {
        deckOfCards = FindObjectOfType<DeckOfCards>();
        playerAmount = defaultPlayerAmount;
        ShowPlayerAmount();
    }

    public void OnStartButtonClick()
    {
        deckOfCards.InitPlayers(playerNames.Take(playerAmount).ToArray());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnAddPlayerButtonClick()
    {
        if(playerAmount < maxPlayerAmount)
        {
            playerAmount++;
            ShowPlayerAmount();
        }
    }

    public void OnRemovePlayerButtonClick()
    {
        if(playerAmount > minPlayerAmount)
        {
            playerAmount--;
            ShowPlayerAmount();
        }
    }

    private void ShowPlayerAmount()
    {
        playerAmountText.text = "Spieleranzahl:" + playerAmount.ToString();
    }
}
