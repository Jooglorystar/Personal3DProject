using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{
    private ItemSO itemData;

    private void Awake()
    {
        itemData = GetComponent<ItemObject>().itemData;
    }

    public void Effect()
    {
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
