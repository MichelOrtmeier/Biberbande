using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cards
{
    //variables
    private CardPiles cardPiles;
    private Player[] players;
    private int playerIndex = 0;

    //constructor
    public Cards(string[] playerNames)
    {
        TroubleshootPlayerNames(playerNames);
        cardPiles = new CardPiles();
        InitPlayers(playerNames);
    }

    private void TroubleshootPlayerNames(string[] playerNames)
    {
        if (playerNames.Length < 2 || playerNames.Length > 6)
        {
            throw new ArgumentOutOfRangeException("playerNames", "Player count must be between 2 and 6.");
        }
    }

    private void InitPlayers(string[] playerNames)
    {
        players = new Player[playerNames.Length];

        for (int i = 0; i < playerNames.Length; i++)
        {
            players[i] = GetInitPlayer(playerNames[i]);
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

    public void SwapDiscardTopForCard(int cardIndex)
    {
        CardType discard = cardPiles.PopFromDiscard();
        cardPiles.PushToDiscard(players[playerIndex].GetCard(cardIndex));
        players[playerIndex].SetCard(discard, cardIndex);
    }

    public void SwapDrawPileTopForCard(int cardIndex)
    {
        CardType draw = cardPiles.PopFromDraw();
        cardPiles.PushToDiscard(players[playerIndex].GetCard(cardIndex));
        players[playerIndex].SetCard(draw, cardIndex);
    }

    //Getter/Setter
    public CardType PeekFromDrawPile() => cardPiles.PeekFromDraw();

    public CardType PeekFromDiscardPile() => cardPiles.PeekFromDiscard();

    public CardType GetCard(int cardIndex) => players[playerIndex].GetCard(cardIndex);
}
