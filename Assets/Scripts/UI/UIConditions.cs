using UnityEngine;

public class UIConditions : MonoBehaviour
{
    public Condition health;

    private void Start()
    {
        PlayerManager.Instance.Player.condition.uiCondition = this;
    }
}
