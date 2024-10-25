using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Heal,
    JumpPlus
}

[CreateAssetMenu(fileName = "DefaultItem", menuName = "ItemSO", order = 0)]
public class ItemSO : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public ItemType type;
    public float effectValue;
}
