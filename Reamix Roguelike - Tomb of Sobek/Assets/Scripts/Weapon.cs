using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform spawnPoint;

    [SerializeField] private float firePower = 20;
    public void Fire()
    {
        Debug.Log("Firing bolt");
        var currentArrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        currentArrow.GetComponent<Rigidbody>().velocity =  - transform.right * firePower * 15;
        currentArrow = null;
    }

}
