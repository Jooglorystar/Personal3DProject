using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemSO itemData;

    public string GetItemData()
    {
        string itemInfo = $"{itemData.itemName}\n{itemData.itemDesc}";
        return itemInfo;
    }

    public void OnInteract()
    {
        PlayerManager.Instance.Player.itemData = itemData;
        PlayerManager.Instance.Player.useItem?.Invoke();
        Destroy(gameObject);
    }
}
