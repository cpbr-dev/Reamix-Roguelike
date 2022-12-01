using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBoltOnActivate : MonoBehaviour
{
    public GameObject bolt;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBolt);
    }

    public void FireBolt(ActivateEventArgs arg)
    {
        GameObject spawnedBolt = Instantiate(bolt, spawnPoint);
        spawnedBolt.GetComponent<Transform>().forward = - spawnPoint.right;
        spawnedBolt.GetComponent<Rigidbody>().velocity = - spawnPoint.right * fireSpeed;
        Destroy(spawnedBolt, 3);
    }
}
