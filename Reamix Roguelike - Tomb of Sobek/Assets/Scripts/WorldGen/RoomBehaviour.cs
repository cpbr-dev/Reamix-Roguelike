using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{

    public GameObject[] doors; // 0 - Up 1 - Down 2 - Right 3 - Left

    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < 4; i++)
        {
            doors[i].SetActive(status[i]);
        }
    }
}
