using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardClickInterpreterFactory : MonoBehaviour
{
    [SerializeField] List<CardClickInterpreterPrefabInput> interpreterPrefabInput = new();

    [Serializable]
    class CardClickInterpreterPrefabInput
    {
        public StateDuringPlayerMove state;
        public GameObject cardClickInterpreter;
    }

    Dictionary<StateDuringPlayerMove, GameObject> interpreterPrefabLookup = new();

    private void OnEnable()
    {
        InitInterpreterPrefabLookup();
    }

    private void InitInterpreterPrefabLookup()
    {
        foreach (CardClickInterpreterPrefabInput interpreterPrefab in interpreterPrefabInput)
        {
            interpreterPrefabLookup.Add(interpreterPrefab.state, interpreterPrefab.cardClickInterpreter);
        }
    }

    public void InstantiateNext(StateDuringPlayerMove next)
    {
        Destroy(GetComponentInChildren<CardClickInterpreter>().gameObject);
        Instantiate(interpreterPrefabLookup[next], transform);
    }
}
