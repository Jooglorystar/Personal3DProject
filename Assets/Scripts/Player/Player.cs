using UnityEngine;

public class Player: MonoBehaviour
{
    private PlayerController controller;

    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
    }
}
