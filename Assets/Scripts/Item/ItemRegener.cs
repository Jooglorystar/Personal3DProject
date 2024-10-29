using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegener : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject spawnedItem;


    private void Update()
    {
        RegenItem();
    }

    private bool CheckItem()
    {
        if (spawnedItem == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void RegenItem()
    {
        if (!CheckItem())
        {
            spawnedItem = Instantiate(prefab, transform);
        }
    }
}
