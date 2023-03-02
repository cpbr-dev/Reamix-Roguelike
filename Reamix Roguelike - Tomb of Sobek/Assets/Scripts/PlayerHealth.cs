using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;
    public int health, maxHealth;

    private void Start()
    {
        health = maxHealth;

    }

    public void TakeDamage(int dmgAmount)
    {
        health -= dmgAmount;
        OnPlayerDamaged?.Invoke();
        if(health<=0)
        {
            health = 0;
            Debug.Log("Youre dead");
            OnPlayerDeath?.Invoke();
        }

    }
}