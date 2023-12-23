using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EqualComponentSingleton : Singleton
{
    [SerializeField] Component referenceComponent;

    protected override bool IsInstanceOfThisType(UnityEngine.Object otherInstance)
    {
        return otherInstance.GetComponents(referenceComponent.GetType()).Any();
    }
}
