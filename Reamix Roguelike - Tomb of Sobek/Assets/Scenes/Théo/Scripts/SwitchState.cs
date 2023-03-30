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

    private float lastClicked;
    private float tileCooldown = 1.0f;

    private MeshRenderer _tileRenderer;
    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player") || lastClicked + tileCooldown < Time.time ) return;
        clicked = true;
        lastClicked = Time.time;
    }

    private void Awake()
    {
        _tileRenderer = GetComponent<MeshRenderer>();
        lastClicked = Time.time; //Tiles are interactable 1 second after start
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

