using System.Collections;
using UnityEngine;

public class ItemRegener : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject spawnedItem;
    [SerializeField] private int spawnCount;
    private float spawnTime = 5f;

    private Coroutine coroutine;

    private void Update()
    {
        if (spawnedItem == null && coroutine == null)
        {
            coroutine = StartCoroutine(RegenItem());
        }
    }

    private IEnumerator RegenItem()
    {
        if (spawnCount > 0)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnedItem = Instantiate(prefab, transform);
            coroutine = null;
            spawnCount--;
        }
        else if (spawnCount == -1)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnedItem = Instantiate(prefab, transform);
            coroutine = null;
        }
    }
}
