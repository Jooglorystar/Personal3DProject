using System;
using UnityEngine;

public class Player: MonoBehaviour
{
    public PlayerCondition condition;
    public PlayerMovement movement;
    public JumpCount jumpCount;

    public ItemSO itemData;
    public ItemEffect itemEffect;

    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        condition = GetComponent<PlayerCondition>();
        movement = GetComponent<PlayerMovement>();
        itemEffect = GetComponent<ItemEffect>();
    }
}
