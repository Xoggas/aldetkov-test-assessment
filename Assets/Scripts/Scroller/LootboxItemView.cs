using AxGrid.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public sealed class LootboxItemView : MonoBehaviourExt
{
    public RectTransform RectTransform { get; private set; }

    public LootboxItemData Data
    {
        set
        {
            icon.sprite = value.Icon;
            rarityBar.color = value.RarityColor;
        }
    }

    [SerializeField]
    [FormerlySerializedAs("_icon")]
    private Image icon;

    [SerializeField]
    [FormerlySerializedAs("_rarityBar")]
    private Image rarityBar;

    [OnAwake]
    private void OnAwake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
}