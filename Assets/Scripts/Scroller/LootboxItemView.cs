using AxGrid.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class LootboxItemView : MonoBehaviourExt
{
    public RectTransform RectTransform { get; private set; }

    public LootboxItemData Data
    {
        set
        {
            _icon.sprite = value.Icon;
            _rarityBar.color = value.RarityColor;
        }
    }

    [SerializeField]
    private Image _icon;

    [SerializeField]
    private Image _rarityBar;

    [OnAwake]
    private void OnAwake()
    {
        RectTransform = GetComponent<RectTransform>();
    }
}