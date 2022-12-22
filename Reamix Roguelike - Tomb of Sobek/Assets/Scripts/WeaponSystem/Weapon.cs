using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float firePower = 20;
    private float cooldown = 2f;
    private float lastShot;
    public static event Action CrossbowShot;
    public void Fire()
    {
        if (Time.time - lastShot < cooldown)
            return;
        
        lastShot = Time.time;
        Debug.Log("Firing bolt.");
        var currentArrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        currentArrow.GetComponent<Rigidbody>().velocity =  - transform.right * firePower * 15;
        currentArrow = null;
        CrossbowShot?.Invoke();
    }

}
