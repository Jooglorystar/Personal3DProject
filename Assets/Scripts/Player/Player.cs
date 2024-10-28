using System;
using UnityEngine;

public class Player: MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public PlayerMovement movement;

    public ItemSO itemData;
    public Action useItem;

    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        condition = GetComponent<PlayerCondition>();
        movement = GetComponent<PlayerMovement>();
    }
}
