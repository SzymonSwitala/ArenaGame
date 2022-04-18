using UnityEngine;

public class Enemy : MonoBehaviour,IDamagable
{
   [SerializeField] protected int healthPoints;
    protected HealthSystem healthSystem;
    protected virtual void Start()
    {
        healthSystem = new HealthSystem(healthPoints);

    }
    public virtual void GetDamage(int value)
    {
        healthSystem.Damage(value);

        if (healthSystem.GetHealth() <= 0)
        {
            Dead();
        }
    }
    public void Dead()
    {
        Destroy(gameObject);
    }




}
