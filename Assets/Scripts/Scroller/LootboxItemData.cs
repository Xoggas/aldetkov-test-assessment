using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Item Data", menuName = "Data/Lootbox Item Data", order = 0)]
public class LootboxItemData : ScriptableObject
{
    public Sprite Icon => icon;
    public Color RarityColor => rarityColor;

    [SerializeField]
    [FormerlySerializedAs("_icon")]
    private Sprite icon;

    [SerializeField]
    [FormerlySerializedAs("_rarityColor")]
    private Color rarityColor = Color.white;
}