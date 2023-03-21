using UnityEngine;

namespace Room_Logic
{
    public class PuzzleRoomManager : MonoBehaviour
    {
        private RoomManager _roomMan;
        public bool triggered;
        private GameObject _puzzleObj;

        private void Start()
        {
            _roomMan = GetComponent<RoomManager>();
            triggered = false;
            _puzzleObj = transform.Find("Puzzle").gameObject;
        }

        public void StartRoom()
        {
            triggered = true;
            _puzzleObj.SetActive(true);
        }
    }
}
