using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachSocketToPlayer : MonoBehaviour
{
    public Transform Target;

    Vector3 offset;

    private void Start() {
        offset = transform.position - Target.position;
    }

    private void LateUpdate() {
        transform.position = Target.position + offset;
        transform.rotation= Target.rotation;
    }
}
