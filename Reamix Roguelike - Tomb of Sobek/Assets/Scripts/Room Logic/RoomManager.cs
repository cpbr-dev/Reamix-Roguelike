using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private List<GameObject> doors;

    void Start()
    {
        doors = new List<GameObject>();
        //Find object named 'Objects' in children
        var obj_parent = this.transform.Find("Objects");

        foreach(Transform child in obj_parent.transform)
        {
            if (child.CompareTag("Door"))
            {
                doors.Add(child.gameObject);
            }
        }
    }

    public void OpenDoors()
    {
        Debug.Log("Opening doors.");
        foreach( GameObject door in doors) {
            door.GetComponent<DoorRemover>().RemoveDoors();
        }
    }
}
