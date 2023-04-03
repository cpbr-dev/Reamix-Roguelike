using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDistraction : MonoBehaviour
{
    public float distractionRadius = 4;
    public float forceThreshold = 1;
    public int guardLayer = 0;
    public LayerMask collisionLayer = 1;

    private void OnCollisionEnter(Collision collision)
    {
        //Check if collision choc is big enough and that collision element is in collision layer
        if(collision.relativeVelocity.magnitude > forceThreshold && ((collisionLayer.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer))
        {
            Collider[] colliders = Physics.OverlapSphere(collision.contacts[0].point, distractionRadius);

            foreach (var item in colliders)
            {
                if(item.gameObject.layer == guardLayer)
                    item.SendMessageUpwards("ForceInvestigation", collision.contacts[0].point, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
