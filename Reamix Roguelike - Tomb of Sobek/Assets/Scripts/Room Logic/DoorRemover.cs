using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRemover : MonoBehaviour
{
    private GameObject nearbyDoor;

    public void RemoveDoors()
    {
        disableObject(nearbyDoor);
        disableObject(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (nearbyDoor == null && collision.gameObject.CompareTag("Door"))
        { //Should only run once on startup
            nearbyDoor = collision.gameObject;
        }
    }

    private void disableObject(GameObject door)
    {
        if (door != null)
        {
            door.SetActive(false);
        }   
    }
}