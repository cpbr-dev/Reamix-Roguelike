using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWeapon : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float firePower = 20;
    [SerializeField] private float cooldown = 2f;

    private float lastShot;

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public void Fire()
    {
        if (Time.time - lastShot < cooldown)
            return;

        lastShot = Time.time;
        Debug.Log("Firing bolt.");
        var currentArrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        currentArrow.GetComponent<Rigidbody>().velocity = transform.forward * firePower * 15;
        currentArrow = null;
    }

}