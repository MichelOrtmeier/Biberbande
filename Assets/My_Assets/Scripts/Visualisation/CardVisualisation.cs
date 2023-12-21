using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.UI.Image))]
public class CardVisualisation : MonoBehaviour
{
    public CardType Value
    {
        get => value;
        set
        {
            this.value = value;
            if (!isShowingBack)
            {
                ShowValue();
            }
        }
    }

    [SerializeField] protected DeckOfCardsVisualisationSO cardAppearance;

    protected CardType value;
    protected UnityEngine.UI.Image visualisation;
    protected bool isShowingBack;

    private void Awake()
    {
        visualisation = GetComponent<UnityEngine.UI.Image>();
    }

    protected virtual void Start()
    {
        isShowingBack = true;
        ShowBack();
    }

    public virtual void Flip()
    {
        if (isShowingBack)
        {
            ShowValue();
        }
        else
        {
            ShowBack();
        }
        isShowingBack = !isShowingBack;
    }

    protected void ShowValue()
    {
        visualisation.sprite = cardAppearance.GetCardVisualisation(Value);
    }

    protected void ShowBack()
    {
        visualisation.sprite = cardAppearance.CardBack;
    }
}