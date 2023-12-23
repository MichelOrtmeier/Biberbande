using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartedMoveCardClickInterpreter : CardClickInterpreter
{
    public override void OnCardClick(int card)
    {
        throw new NotImplementedException();
    }

    public override void OnDiscardPileClick()
    {
        deckOfCards.MoveOnToNextPlayer();
        gameScreen.ShowInitialDiscardPileSelection();
        interpreterFactory.InstantiateNext(StateDuringPlayerMove.SelectedDiscardPile);
    }

    public override void OnDrawPileClick()
    {
        deckOfCards.MoveOnToNextPlayer();
        gameScreen.ShowInitialDrawPileSelection();
        interpreterFactory.InstantiateNext(StateDuringPlayerMove.SelectedDrawPile);
    }
}