using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReceivedMagnifierCardClickInterpreter : CardClickInterpreter
{
    bool wasAlreadyUsed = false; 

    public override void OnCardClick(int card)
    {
        if (wasAlreadyUsed)
        {
            deckOfCards.SwapDrawPileTopForDiscardPileTop();
            gameScreen.ShowUsedMagnifier();
            interpreterFactory.InstantiateNext(StateDuringPlayerMove.StartedMove);
        }
        else
        {
            wasAlreadyUsed = true;
            gameScreen.ShowUseMagnifierFor(card);
        }
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