using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveThaBall : MonoBehaviour
{

    //public float speed = 10.0f; // Speed at which the ball will roll
    //private Rigidbody rb; // Reference to the ball's Rigidbody component

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>(); // Get the Rigidbody component from the ball
    //}

    //void FixedUpdate()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal"); // Get input from the left/right arrow keys
    //    float moveVertical = Input.GetAxis("Vertical"); // Get input from the up/down arrow keys

    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Create a new vector to store the movement input
    //    rb.AddForce(movement * speed); // Apply the movement input to the ball
    //}


 

    // public float speed = 10.0f; // Speed at which the ball will roll
    // private Rigidbody rb; // Reference to the ball's Rigidbody component

    // void Start()
    // {
    //     rb = GetComponent<Rigidbody>(); // Get the Rigidbody component from the ball
    // }

    // void FixedUpdate()
    // {
    //     // Get input from the arrow keys
    //     float moveHorizontal = Input.GetAxis("Horizontal");
    //     float moveVertical = Input.GetAxis("Vertical");

    //     // Create a movement vector based on the arrow key inputs
    //     Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    //     // Normalize the movement vector to ensure that diagonal movement isn't faster than horizontal/vertical movement
    //     if (movement.magnitude > 1.0f)
    //     {
    //         movement.Normalize();
    //     }

    //     // Calculate the new position of the ball based on its current position and the movement vector
    //     Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;

    //     // Move the ball to the new position
    //     rb.MovePosition(newPosition);
    // }




    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    
}


}





