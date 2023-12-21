using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCardVisualisation : CardVisualisation
{
    protected override void Start()
    {
        isShowingBack = false;
        ShowValue();
    }

    public override void Flip()
    {
        ShowValue();
    }
}
