using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

    int playerAmount;
    const int minPlayerAmount = 2;
    const int maxPlayerAmount = 6;

    private void Start()
    {
        playerAmount = defaultPlayerAmount;
        ShowPlayerAmount();
    }

    public void OnStartButtonClick()
    {

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
