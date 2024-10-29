using UnityEngine;
using UnityEngine.SceneManagement;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    Condition health { get {  return uiCondition.health; } }

    private void Update()
    {
        if (health.curValue <= 0)
        {
            Die();
        }
    }
    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
    }

    public void Heal(float value)
    {
        health.Add(value);
    }

    private void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
