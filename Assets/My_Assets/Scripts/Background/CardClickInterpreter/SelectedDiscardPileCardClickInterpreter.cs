using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SelectedDiscardPileCardClickInterpreter : CardClickInterpreter
{
    public override void OnCardClick(int card)
    {
        deckOfCards.SwapDiscardPileTopForCard(card);
        gameScreen.ShowSwapDiscardPileTopForCard(card);
        interpreterFactory.InstantiateNext(StateDuringPlayerMove.StartedMove);
    }

    public override void OnDiscardPileClick()
    {
        throw new NotImplementedException();
    }

    public override void OnDrawPileClick()
    {
        throw new NotImplementedException();
    }
}