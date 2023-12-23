using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Singleton : MonoBehaviour
{
    private void Awake()
    {
        if (OtherInstancesOfThisTypeExist())
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private bool OtherInstancesOfThisTypeExist()
    {
        return FindObjectsOfType(GetType()).Any(instance => instance != this && IsInstanceOfThisType(instance));
    }

    protected abstract bool IsInstanceOfThisType(Object otherInstance);
}
