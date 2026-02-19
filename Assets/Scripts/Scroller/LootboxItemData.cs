using UnityEngine;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Data/Lootbox Item Data", order = 0)]
public class LootboxItemData : ScriptableObject
{
    public Sprite Icon => _icon;
    public Color RarityColor => _rarityColor;

    [SerializeField]
    private Sprite _icon;

    [SerializeField]
    private Color _rarityColor = Color.white;
}