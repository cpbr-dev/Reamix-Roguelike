using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;


public class SwitchState : MonoBehaviour
{
    [SerializeField] private Mesh activatedMesh;
    [SerializeField] private Mesh deactivatedMesh;
    public bool clicked = false;
    public bool tileState;

    private float lastClicked;
    private float tileCooldown = 1.0f;

    private MeshFilter _meshFilter;
    
    
    private float duration = 1f;
    private Vector3 initialPosition;

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player") && !(Time.time - lastClicked > tileCooldown)) return;
        clicked = true;
        lastClicked = Time.time;
    }

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        initialPosition = transform.position;
        lastClicked = Time.time; //Tiles are interactable 1 second after start
    }

    public void InitBlock(GameObject block)
    {
        _meshFilter.mesh = deactivatedMesh;
        
        tileState = false;
    }

    public void Switch()
    {
        MoveDown();
        
        if (tileState)
        {
            _meshFilter.mesh = deactivatedMesh;
            
            tileState = false;
        }
        else
        {
            _meshFilter.mesh = activatedMesh;
            tileState = true;
        }
    }
    
    private void MoveDown()
    {
        Vector3 targetPosition = initialPosition - Vector3.up * 0.2f;
        StartCoroutine(MoveToPosition(targetPosition));
    }
    
    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        StartCoroutine(MoveUp());
    }

    private IEnumerator MoveUp()
    {
        Vector3 targetPosition = initialPosition;
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}

