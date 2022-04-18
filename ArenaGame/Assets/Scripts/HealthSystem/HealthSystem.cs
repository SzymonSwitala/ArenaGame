using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem 
{
    private int health;
    private int maxHealth;
    public HealthSystem(int health)
    {
        this.health = health;
    }
    private void Start()
    {
        maxHealth = health;
    }

    public int GetHealth()
    {
        return health;
    }
    public void Damage(int value)
    {
        health -= value;

        if (health <= 0)
        {
            health = 0;
        }

    }
}
