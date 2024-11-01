using System.Collections;
using UnityEngine;

public class ItemRegener : MonoBehaviour
{
    public GameObject prefab;
    private GameObject spawnedItem;
    public int spawnCount;
    private float spawnTime = 5f;

    private Coroutine coroutine;

    private void Start()
    {
        spawnedItem = Instantiate(prefab, transform);
        spawnCount--;
    }

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
        else if (spawnCount <= -1)
        {
            yield return new WaitForSeconds(spawnTime);
            spawnedItem = Instantiate(prefab, transform);
            coroutine = null;
        }
    }
}
