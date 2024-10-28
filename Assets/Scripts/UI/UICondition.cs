using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;

    private void Start()
    {
        PlayerManager.Instance.Player.condition.uiCondition = this;
    }
}
