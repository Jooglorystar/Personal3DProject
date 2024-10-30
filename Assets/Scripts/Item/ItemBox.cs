using TMPro;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private TextMeshPro itemNameText;
    [SerializeField] private TextMeshPro itemCountText;
    private ItemRegener itemRegener;
    private ItemSO itemData;

    private void Awake()
    {
        itemRegener = GetComponentInChildren<ItemRegener>();
        itemData = itemRegener.prefab.GetComponent<ItemObject>().itemData;
    }

    private void Start()
    {
        itemNameText.text = itemData.itemName;
        if (itemRegener.spawnCount >= 0)
        {
            itemCountText.text = (itemRegener.spawnCount + 1).ToString();
        }
        else
        {
            itemCountText.text = "¡Ä";
        }
    }
}
