using System.Collections;
using System.Collections.Generic;
using Room_Logic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private List<GameObject> doors;
    private bool triggered;

    private CombatRoomManager _combatRoomManager;
    private PuzzleRoomManager _puzzleRoomManager;
    void Start()
    {

        _combatRoomManager = GetComponent<CombatRoomManager>();
        _puzzleRoomManager = GetComponent<PuzzleRoomManager>();
        
        triggered = false;
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
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Trigger entered");
        if (triggered) return;

        if (collision.gameObject.CompareTag("Player") ) {
            triggered = true;
            if (_combatRoomManager.enabled)
            {
                _combatRoomManager.StartRoom();
            }
            else
            {
                _puzzleRoomManager.StartRoom();
            }
        }
    }
}
