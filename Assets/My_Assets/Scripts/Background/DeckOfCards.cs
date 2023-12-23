using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//es wäre besser, die playerIndex gameloop in einer anderen Klasse unterzubringen oder zu vererben
//Swap Methoden erzeugen switch -> in Polymorphismus umwandeln
public class DeckOfCards : MonoBehaviour
{
    //variables
    private CardPiles cardPiles = new CardPiles();
    private Player[] players;
    private int playerIndex = 0;

    public void InitPlayers(string[] playerNames)
    {
        TroubleshootPlayerNames(playerNames);
        players = new Player[playerNames.Length];

        for (int i = 0; i < playerNames.Length; i++)
        {
            players[i] = GetInitPlayer(playerNames[i]);
        }
    }

    private void TroubleshootPlayerNames(string[] playerNames)
    {
        if (playerNames.Length < 2 || playerNames.Length > 6)
        {
            throw new ArgumentOutOfRangeException("playerNames", "Player count must be between 2 and 6.");
        }
    }

    private Player GetInitPlayer(string name)
    {
        Player player = new Player(name);
        for (int i = 0; i < 4; i++)
        {
            player.SetCard(cardPiles.PopFromDraw(), i);
        }
        return player;
    }

    //methods
    public void MoveOnToNextPlayer()
    {
        playerIndex = (playerIndex + 1) % players.Length;
    }

    public void SwapDiscardPileTopForCard(int cardIndex)
    {
        Card discard = cardPiles.PopFromDiscard();
        cardPiles.PushToDiscard(players[playerIndex].GetCard(cardIndex));
        players[playerIndex].SetCard(discard, cardIndex);
    }

    public void SwapDrawPileTopForCard(int cardIndex)
    {
        Card draw = cardPiles.PopFromDraw();
        cardPiles.PushToDiscard(players[playerIndex].GetCard(cardIndex));
        players[playerIndex].SetCard(draw, cardIndex);
    }

    public void SwapDrawPileTopForDiscardPileTop() => cardPiles.DiscardDrawPileTop();

    //Getter/Setter
    public Card PeekFromDrawPile() => cardPiles.PeekFromDraw();

    public Card PeekFromDiscardPile() => cardPiles.PeekFromDiscard();

    public Card GetCard(int cardIndex) => players[playerIndex].GetCard(cardIndex);

    public string GetPlayerName() => players[playerIndex].Name;
}
