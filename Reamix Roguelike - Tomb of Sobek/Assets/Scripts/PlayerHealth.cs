using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;
    public float health, maxHealth;

    private void start()
    {
        health = maxHealth;

    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        OnPlayerDamaged?.Invoke();
        if(health<=0)
        {
            health = 0;
            Debug.Log("Youre dead");
            OnPlayerDeath?.Invoke();
        }

    }
}