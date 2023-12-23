using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SelectedDrawPileCardClickInterpreter : CardClickInterpreter
{
    public override void OnCardClick(int card)
    {
        deckOfCards.SwapDrawPileTopForCard(card);
        gameScreen.ShowSwapDrawPileTopForCard(card);
        interpreterFactory.InstantiateNext(StateDuringPlayerMove.StartedMove);
    }

    public override void OnDiscardPileClick()
    {
        deckOfCards.SwapDrawPileTopForDiscardPileTop();
        gameScreen.ShowSwapDrawPileTopForDiscardPileTop();
        interpreterFactory.InstantiateNext(StateDuringPlayerMove.StartedMove);
    }

    public override void OnDrawPileClick()
    {
        throw new NotImplementedException();
    }
}