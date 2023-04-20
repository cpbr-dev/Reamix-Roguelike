using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    DestroyManager _destroyManager;
    public float currHealth;
    [SerializeField] public float maxHealth = 10f;
    [SerializeField] private HeartHealthBar heartHealthBar;

    void Start()
    {
        currHealth = maxHealth;
        heartHealthBar.AddContainer();
        heartHealthBar.SetCurrentHealth( (int) maxHealth);
        heartHealthBar.SetupHearts((int) maxHealth);
        _destroyManager = GetComponent<DestroyManager>();
    }
    
    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        Debug.Log(gameObject.name + " received damage: " + damage);
        Debug.Log(gameObject.name + "'s current HP: " + currHealth);
        heartHealthBar.RemoveHearts(damage);
        if (currHealth <= 0  && !this.CompareTag("Player")) {
            
            if(_destroyManager is not null){ 
                _destroyManager.KillObject();
            } else {
                Destroy(this);
            }
            
            Debug.Log(gameObject.name + " has died.");
        } else if (currHealth <= 0 && this.CompareTag("Player")) {
            //TODO: Add game over screen.
        }
    }

    public void HealDamage(float health)
    {
        currHealth += health;
        Debug.Log(gameObject.name + " received healing: " + health);
        Debug.Log(gameObject.name + "'s current HP: " + currHealth);
        
        if (currHealth <= 0  && !this.CompareTag("Player")) {
            
            if(_destroyManager is not null){ 
                _destroyManager.KillObject();
            } else {
                Destroy(this);
            }
            
            Debug.Log(gameObject.name + " has died.");
        }
    }
}
