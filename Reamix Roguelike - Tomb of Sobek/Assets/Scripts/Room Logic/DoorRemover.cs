using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorRemover : MonoBehaviour
{
    private GameObject nearbyDoor;
    [SerializeField] private Transform doorPos;
    private void Start()
    {
        detectDoors();
    }

    public void RemoveDoors()
    {
        //Debug.Log("Disabling nearbyDoor.");
        disableObject(nearbyDoor);
        //Debug.Log("Disabling self.");
        disableObject(this.gameObject);
    }

    private void disableObject(GameObject door)
    {
        if (door != null)
        {
            door.SetActive(false);
            return;
        }
        //Debug.Log("door is null, not disabling");
    }

    private void detectDoors()
    {
        //Debug.Log("Searching for doors");
        Collider[] hitColliders = Physics.OverlapSphere(doorPos.position, 1);
        //Debug.Log("Found " + hitColliders.Length + " objects nearby, checking for door tag");
        for (int i = 0; i < hitColliders.Length; i++){
            GameObject hitCollider = hitColliders[i].gameObject;
            if ( hitCollider.gameObject.CompareTag("Door") && (hitCollider.transform.position != transform.position) ) {
                //Debug.Log("Found the door, setting it to nearbyDoor");
                nearbyDoor = hitCollider.gameObject;
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(doorPos.position, 1);
    }

}