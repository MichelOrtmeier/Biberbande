using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum StateDuringPlayerMove//describes the state(, which is currently reached in GameScreen.cs) -> phase, in which the player has already done a particular thing
{
    StartedMove = 0,
    SelectedDrawPile = 1,
    SelectedDiscardPile = 2,
    ReceivedMagnifier = 3,
}