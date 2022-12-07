using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBehaviour : MonoBehaviour
{
    private bool didHit;
    private Rigidbody rb;

    [SerializeField]
    private float torque;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Fly(Vector3 force)
    {
        rb.isKinematic = false;
        rb.AddForce(force, ForceMode.Impulse);
        rb.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (didHit) return;
        didHit = true;

        /*if (collider.CompareTag(enemyTag))
        {
            var health = collider.GetComponent<HealthController>();
            health.ApplyDamage(damage);
        }*/

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        transform.SetParent(collider.transform);
    }
}
