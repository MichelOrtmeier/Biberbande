using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OpenCardVisualisation : CardVisualisation
{
    public override void ShowBack()
    {
        base.ShowValue();
    }
}