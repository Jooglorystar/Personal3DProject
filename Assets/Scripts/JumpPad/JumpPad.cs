using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = PlayerManager.Instance.Player.gameObject.GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            PlayerManager.Instance.Player.movement.jumpTime -= PlayerManager.Instance.Player.movement.maxJumpTime;
            PlayerManager.Instance.Player.jumpCount.UpdateJumpCount(PlayerManager.Instance.Player.movement.jumpTime);
        }
    }
}
