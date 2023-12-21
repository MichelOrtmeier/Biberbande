using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCardVisualisation : CardVisualisation
{
    protected override void InitShowCardSide()
    {
        isShowingBack = false;
        ShowValue();
    }

    public override void Flip()
    {
        ShowValue();
    }
}
