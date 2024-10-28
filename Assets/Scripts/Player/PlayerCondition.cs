using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    Condition health { get {  return uiCondition.health; } }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
    }

    public void Heal(float value)
    {
        health.Add(value);
    }
}
