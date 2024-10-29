using UnityEngine;

public enum ItemType
{
    Heal,
    JumpPlus,
    SpeedUp
}

[CreateAssetMenu(fileName = "DefaultItem", menuName = "ItemSO", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public string itemDesc;
    public ItemType type;
    public float effectValue;
}
