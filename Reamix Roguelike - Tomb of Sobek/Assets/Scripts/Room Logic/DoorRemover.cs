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

    private void disableObject(GameObject door)
    {
        if (door != null)
        {
            door.SetActive(false);
        }   
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        if ( collision.gameObject.CompareTag("Door") ){
            nearbyDoor = collision.gameObject;
            Debug.Log("Object linked : " + nearbyDoor.name);
        }
    }


}