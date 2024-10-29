using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    private ItemSO itemData;

    public void Effect()
    {
        itemData = PlayerManager.Instance.Player.itemData;
        switch (itemData.type)
        {
            case ItemType.Heal:
                PlayerManager.Instance.Player.condition.Heal(itemData.effectValue);
                break;

            case ItemType.SpeedUp:
                StartCoroutine(SpeedEffectCoroutine(itemData.effectValue));
                StopCoroutine(SpeedEffectCoroutine(itemData.effectValue));
                break;

            case ItemType.JumpPlus:
                PlayerManager.Instance.Player.movement.jumpTime += 1;
                break;

            default:
                break;
        }
    }

    private IEnumerator SpeedEffectCoroutine(float value)
    {
        PlayerManager.Instance.Player.movement.moveSpeed *= value;
        yield return new WaitForSeconds(3f);
        PlayerManager.Instance.Player.movement.moveSpeed /= value;
    }
}
