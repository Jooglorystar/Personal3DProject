using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownPoint : MonoBehaviour
{
    private Vector3 startPoint;

    private void Start()
    {
        startPoint = PlayerManager.Instance.Player.gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Player":
                other.gameObject.transform.position = startPoint;
                other.gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
                PlayerManager.Instance.Player.condition.TakePhysicalDamage(50);
                break;

            case "Item":
                Destroy(other.gameObject);
                break;
        }
    }
}
