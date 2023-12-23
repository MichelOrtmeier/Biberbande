using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

internal class EqualTagSingleton : Singleton
{
    protected override bool IsInstanceOfThisType(UnityEngine.Object otherInstance)
    {
        return otherInstance.GameObject().tag == tag;
    }
}
