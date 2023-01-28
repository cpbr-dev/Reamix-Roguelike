using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCrossbow : MonoBehaviour
{
    [SerializeField] private GameObject holster;
    private Rigidbody crossbowRb;
    private void Start()
    {
        crossbowRb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        var resetPos = holster.transform.position;
        if (crossbowRb.transform.position.y <= 1.2)
        {
            crossbowRb.velocity = Vector3.zero;
            this.transform.position = holster.transform.position;
        }
    }
}
