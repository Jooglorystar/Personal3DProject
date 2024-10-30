using UnityEngine;

public class JumpSensor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground") && PlayerManager.Instance.Player.movement.jumpTime != PlayerManager.Instance.Player.movement.maxJumpTime)
        {
            PlayerManager.Instance.Player.movement.jumpTime = PlayerManager.Instance.Player.movement.maxJumpTime;
            PlayerManager.Instance.Player.jumpCount.UpdateJumpCount(PlayerManager.Instance.Player.movement.jumpTime);
        }
    }
}
