using UnityEngine;

public class FallDown : MonoBehaviour
{
    private Vector3 startPoint;

    private void Start()
    {
        startPoint = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GameController"))
        {
            transform.position = startPoint;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            PlayerManager.Instance.Player.condition.TakePhysicalDamage(30);
        }
    }
}
