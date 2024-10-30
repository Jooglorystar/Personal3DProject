using TMPro;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private TextMeshPro itemNameText;
    private ItemSO itemData;

    private void Awake()
    {
        itemData = GetComponentInChildren<ItemRegener>().prefab.GetComponent<ItemObject>().itemData;
    }

    private void Start()
    {
        itemNameText.text = itemData.itemName;
    }
}
