using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BoltBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float torque;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Environment"))
        {
            rb.isKinematic = true;
            transform.parent = collision.transform;
            gameObject.GetComponent<Collider>().enabled = false;
            /* If it's an enemy, drop its health */
            Destroy(this, 8f);
        }
    }
}
