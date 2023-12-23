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
    public Card Value
    {
        get => value;
        set
        {
            this.value = value;
            if (isShowingBack)
            {
                ShowBack();
            }
            else
            {
                ShowValue();
            }
        }
    }
    private bool isShowingBack = true;

    [SerializeField] private DeckOfCardsVisualisationSO cardAppearance;
    [SerializeField] private Color highlightingColor;
    [SerializeField] private Color defaultColor = Color.white;

    private UnityEngine.UI.Image visualisation;
    private UnityEngine.UI.Button selectButton;
    private Card value;

    private void Awake()
    {
        visualisation = GetComponent<UnityEngine.UI.Image>();
        selectButton = GetComponent<UnityEngine.UI.Button>();
    }

    public void Flip()
    {
        if (isShowingBack)
        {
            ShowValue();
        }
        else
        {
            ShowBack();
        }
    }

    public void ShowValue()
    {
        isShowingBack = false;
        visualisation.sprite = cardAppearance.GetCardVisualisation(Value);
    }

    public virtual void ShowBack()
    {
        isShowingBack = true;
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
        selectButton.interactable = false;
    }

    public void EnableButton()
    {
        selectButton.interactable = true;
    }
}