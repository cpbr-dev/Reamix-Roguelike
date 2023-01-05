using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStatus : MonoBehaviour
{
    public bool[] status;   // 0 - Up 1 - Down 2 - Right 3 - Left

    public bool PossibleRoom(bool[] statusRequire)
    {
        if (status[0] == statusRequire[0] && status[1] == statusRequire[1] && status[2] == statusRequire[2] && status[3] == statusRequire[3])
        {
            return true;    
        }
        return false;
    }
}
