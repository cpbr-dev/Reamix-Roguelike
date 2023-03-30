using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;


public class SwitchState : MonoBehaviour
{
    [SerializeField] private Material activated;
    [SerializeField] private Material deactivated;
    public bool clicked = false;
    public bool tileState;

    private MeshRenderer _tileRenderer;
    public void OnMouseDown()
    {
        clicked = true;
    }

    private void Awake()
    {
        _tileRenderer = GetComponent<MeshRenderer>();
    }

    public void InitBlock(GameObject block)
    {
        _tileRenderer.material = deactivated;
        tileState = false;
    }

    public void Switch()
    {
        if (tileState)
        {
            _tileRenderer.material = deactivated;
            tileState = false;
        }
        else
        {
            _tileRenderer.material = activated;
            tileState = true;
        }
    }
}

