using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UIConditions uiCondition;

    Condition health { get {  return uiCondition.health; } }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
    }
}
