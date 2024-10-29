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
        PlayerManager.Instance.Player.itemEffect.Effect();
        Destroy(gameObject);
    }
}
