using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousedetector : MonoBehaviour
{
    public GameObject arrowTarget; // The arrow target prefab
    private Rigidbody rb;
    public float speed = 5f;
    GameObject ball;


    private Vector3 targetPosition; // The target position for smooth movement
    private bool isMoving = false; // Flag to indicate if the arrow is currently moving

    void Start()
    {
        rb = arrowTarget.GetComponent<Rigidbody>();
        targetPosition = rb.position;
        
    }

    void Update()
    {
        if (isMoving)
        {
            // Move the arrow towards the target position using MovePosition
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, speed * Time.deltaTime));

            // Check if the arrow has reached the target position
            if (rb.position == targetPosition)
            {
                isMoving = false;
                rb.velocity = Vector3.zero; // Reset velocity to stop any residual movement
            }
        }
    }

    void OnMouseDown()
    {
        float moveHorizontal = 0;
        float moveVertical = 0;

        switch (gameObject.name)
        {
            case "UpArrow":
                moveVertical = 1;
                break;
            case "DownArrow":
                moveVertical = -1;
                break;
            case "RightArrow":
                moveHorizontal = 1;
                break;
            case "LeftArrow":
                moveHorizontal = -1;
                break;
            default:
                break;
        }

        // Calculate the new target position based on the movement direction
        targetPosition = rb.position + new Vector3(moveHorizontal, 0.0f, moveVertical);
        isMoving = true;

        Debug.Log("Click detected on " + gameObject.name);
    }
}
