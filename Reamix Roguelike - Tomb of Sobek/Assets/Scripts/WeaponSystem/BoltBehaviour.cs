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
            var myScript = collision.gameObject.GetComponent<ObjectHpManager>();
            if (myScript != null ) {
                myScript.DropHealth(1f);
            }
            Destroy(this); //Remove bolt now, object already disappeared
        } else {
            Destroy(this, 5f); // Remove bolt after 5s, let it stick
        }
    }
}
