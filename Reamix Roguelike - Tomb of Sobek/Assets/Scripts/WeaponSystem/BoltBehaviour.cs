using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BoltBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public LayerMask layer;
    [SerializeField] private float torque;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || (layer.value & 1 << collision.gameObject.layer) > 0 )
        {
            rb.isKinematic = true;
            transform.parent = collision.transform;
            gameObject.GetComponent<Collider>().enabled = false;
            /* If it's an enemy, drop its health */
            Destroy(this, 5f);
        }
        Destroy(this, 5f);
    }
}
