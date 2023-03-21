using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightsOut : MonoBehaviour
{
    private List<SwitchState> _initTiles = new List<SwitchState>();
    private List<SwitchState> _blocks = new List<SwitchState>();
    private bool _endGame;

    [SerializeField] private RoomManager roomManager;
    // Start is called before the first frame update
    void Start()
    {
        // GameObjects need to be properly ordered in the hierarchy of Unity in order for this algorithm to work
        // From top-left to bottom-right, one row at a time

        GameObject[] blocksArray = GameObject.FindGameObjectsWithTag("Lights_out");
        foreach (GameObject b in blocksArray)
        {
            var swState = b.GetComponent<SwitchState>();
            _blocks.Add(swState);
            _initTiles.Add(swState);
            swState.Switch();
        }
        InitGame();
    }


    private void Update()
    {
        foreach (SwitchState currTileState in _blocks)
        {
            if (currTileState.clicked) // Check if a block is clicked
            {
                currTileState.Switch();
                SwitchNeighbours(currTileState); // Switch their neighbours
                currTileState.clicked = false;
                CheckVictory();
            }
        }
    }

    void SwitchNeighbours(SwitchState tile)
    {
        int index = _blocks.IndexOf(tile);
        int dimension = Mathf.RoundToInt(Mathf.Sqrt(_blocks.Count));
        
        // Top and bottom neighbours

        // Block on the top column
        if (index < dimension)
        {
            _blocks[index + dimension].Switch(); // Bottom neighbor switch
        }
        // Block on the bottom column
        else if (index > _blocks.Count - dimension - 1)
        {
            _blocks[index - dimension].Switch(); // Top neighbor switch
        }
        else
        {
            _blocks[index + dimension].Switch(); // Bottom neighbor switch
            _blocks[index - dimension].Switch(); // Top neighbor switch
        }


        // Left and rights neighbours

        List<int> leftRowIndexes = new List<int>();
        for (int i = 0; i < _blocks.Count; i += dimension)
        {
            leftRowIndexes.Add(i);
        }

        List<int> rightRowIndexes = new List<int>();
        for (int i = dimension - 1; i < _blocks.Count; i += dimension)
        {
            rightRowIndexes.Add(i);
        }

        // Block on the left column
        if (leftRowIndexes.Contains(index))
        {
            _blocks[index + 1].Switch(); // Right neighbor switch
        }
        // Block on the right column
        else if (rightRowIndexes.Contains(index))
        {
            _blocks[index - 1].Switch(); // Left neighbor switch
        }
        else
        {
            _blocks[index + 1].Switch(); // Right neighbor switch
            _blocks[index - 1].Switch(); // Left neighbor switch
        }
        
    }

    void InitGame()
    {
        int n = Random.Range(2, 9); // Number of active block at the beginning
        for (int i = 0; i < n; i++)
        {
            int b = Random.Range(0, _initTiles.Count);
            _initTiles[b].GetComponent<SwitchState>().Switch();
            _initTiles.RemoveAt(b);
        }
    }

    void CheckVictory()
    {
        Debug.Log("Checking game state.");
        foreach (SwitchState b in _blocks) //Turn off all lights to win
        {
            if (!b.tileState)
            {
                return;
            }
        }
        Debug.Log("Victory !");
        this.GetComponent<LightsOut>().enabled = false;
        if(roomManager != null) roomManager.OpenDoors();
    }
}
