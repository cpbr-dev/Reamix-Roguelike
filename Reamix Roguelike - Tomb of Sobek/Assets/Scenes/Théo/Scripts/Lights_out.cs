using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lights_out : MonoBehaviour
{
    public List<GameObject> garbageBlocks;
    public List<GameObject> blocks;
    private bool endGame;

    // Start is called before the first frame update
    void Start()
    {
        // GameObjectes need to be properly ordered in the hierarchy of Unity in order for this algorithm to work
        // From top-left to bottom-right, one row at a time

        GameObject[] blocksArray = GameObject.FindGameObjectsWithTag("Lights_out");
        foreach (GameObject b in blocksArray)
        {
            blocks.Add(b);
            garbageBlocks.Add(b);
            b.GetComponent<SwitchState>().Switch();
        }
        InitGame();
    }

    private void Update()
    {
        foreach (GameObject b in blocks)
        {
            if (b.GetComponent<SwitchState>().clicked) // Check if a block is clicked
            {
                b.GetComponent<SwitchState>().Switch();
                SwitchNeighbours(b); // Switch their neighbours
                b.GetComponent<SwitchState>().clicked = false;
            }
        }
        endGame = CheckVictory();
        Debug.Log(endGame);
    }

    void SwitchNeighbours(GameObject b)
    {
        int index = blocks.IndexOf(b);
        int dimension = Mathf.RoundToInt(Mathf.Sqrt(blocks.Count));
        
        // Top and bottom neighbours

        // Block on the top column
        if (index < dimension)
        {
            blocks[index + dimension].GetComponent<SwitchState>().Switch(); // Bottom neighbor switch
        }
        // Block on the bottom column
        else if (index > blocks.Count - dimension - 1)
        {
            blocks[index - dimension].GetComponent<SwitchState>().Switch(); // Top neighbor switch
        }
        else
        {
            blocks[index + dimension].GetComponent<SwitchState>().Switch(); // Bottom neighbor switch
            blocks[index - dimension].GetComponent<SwitchState>().Switch(); // Top neighbor switch
        }


        // Left and rights neighbours

        List<int> leftRowIndexes = new List<int>();
        for (int i = 0; i < blocks.Count; i += dimension)
        {
            leftRowIndexes.Add(i);
        }

        List<int> rightRowIndexes = new List<int>();
        for (int i = dimension - 1; i < blocks.Count; i += dimension)
        {
            rightRowIndexes.Add(i);
        }

        // Block on the left column
        if (leftRowIndexes.Contains(index))
        {
            blocks[index + 1].GetComponent<SwitchState>().Switch(); // Right neighbor switch
        }
        // Block on the right column
        else if (rightRowIndexes.Contains(index))
        {
            blocks[index - 1].GetComponent<SwitchState>().Switch(); // Left neighbor switch
        }
        else
        {
            blocks[index + 1].GetComponent<SwitchState>().Switch(); // Right neihbor switch
            blocks[index - 1].GetComponent<SwitchState>().Switch(); // Left neighbor switch
        }
        
    }

    void InitGame()
    {
        int n = Random.Range(2, 9); // Number of active block at the beginning
        for (int i = 0; i < n; i++)
        {
            int b = Random.Range(0, garbageBlocks.Count);
            garbageBlocks[b].GetComponent<SwitchState>().Switch();
            garbageBlocks.RemoveAt(b);
        }
    }

    bool CheckVictory()
    {
        bool victory = true;
        foreach (GameObject b in blocks)
        {
            if (b.GetComponent<MeshRenderer>().material.GetColor("_Color") == b.GetComponent<SwitchState>().deactivate)
            {
                victory = false; break;
            }
        }
        return victory;
    }
}
