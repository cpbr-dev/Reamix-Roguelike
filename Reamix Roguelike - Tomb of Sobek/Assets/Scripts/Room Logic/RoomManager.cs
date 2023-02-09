using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    //Once conditions are met in a room, open the doors that are closed
    //and the doors that are linked to it
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            OpenDoors();
        }
    }
    void OpenDoors()
    {

    }
}
