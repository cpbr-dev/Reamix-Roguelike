using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHpManager : MonoBehaviour
{
    DestroyManager destroyManager;
    [SerializeField] private float currHealth = 10f;

    void Start()
    {
        destroyManager = GetComponent<DestroyManager>();
    }


    public void DropHealth(float damage)
    {
        currHealth -= damage;
        Debug.Log(gameObject.name + " received damage: " + damage);
        Debug.Log(gameObject.name + "'s current HP: " + currHealth);
        if (currHealth <= 0) {
            destroyManager.KillObject();
            Debug.Log(gameObject.name + " has died.");
        }
    }
}
