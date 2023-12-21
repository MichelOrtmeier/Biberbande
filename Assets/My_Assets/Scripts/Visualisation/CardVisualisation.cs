using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.UI.Image))]
[RequireComponent(typeof(UnityEngine.UI.Button))]
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
    protected bool isShowingBack;

    [SerializeField] private DeckOfCardsVisualisationSO cardAppearance;
    [SerializeField] private Color highlightingColor;

    private UnityEngine.UI.Image visualisation;
    private UnityEngine.UI.Button selectButton;
    private CardType value;
    private Color defaultColor;

    private void Awake()
    {
        visualisation = GetComponent<UnityEngine.UI.Image>();
    }

    private void Start()
    {
        defaultColor = visualisation.color;
        selectButton.enabled = true;
        InitShowCardSide();
    }

    protected virtual void InitShowCardSide()
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

    public void Highlight()
    {
        visualisation.color = highlightingColor;
    }

    public void StopHighlight()
    {
        visualisation.color = defaultColor;
    }

    public void DisableButton()
    {
        selectButton.enabled = false;
    }

    public void EnableButton()
    {
        selectButton.enabled = true;
    }
}