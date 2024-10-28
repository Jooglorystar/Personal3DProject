using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemSO itemData;
    private ItemEffect effect;

    private void Awake()
    {
        effect = GetComponent<ItemEffect>();
    }

    public string GetItemData()
    {
        string itemInfo = $"{itemData.itemName}\n{itemData.itemDesc}";
        return itemInfo;
    }

    public void OnInteract()
    {
        effect.Effect();
        //Destroy(gameObject);
    }
}
