using System.Collections.Generic;
using UnityEngine;

public class JumpCount : MonoBehaviour
{
    [SerializeField] private List<GameObject> jumps = new List<GameObject>();

    private void Start()
    {
        UpdateJumpCount(PlayerManager.Instance.Player.movement.jumpTime);
    }

    public void UpdateJumpCount(int jumpTime)
    {
        for (int i = 0; i < jumps.Count; i++)
        {
            if (i < jumps.Count) jumps[i].SetActive(false);
        }

        for (int i = 0; i < jumpTime; i++)
        {
            if (i < jumps.Count) jumps[i].SetActive(true);
        }
    }
}

