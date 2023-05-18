using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveThaBall : MonoBehaviour
{
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

    // public GameObject arrow; // The arrow prefab

    // private Vector3 direction; // The direction to move the ball
    // private float speed = 5f; // The speed to move the ball

    // private void OnMouseDown()
    // {
    //     // Instantiate the arrow prefab
    //     GameObject arrowInstance = Instantiate(arrow, transform.position, Quaternion.identity);

    //     // Set the arrow instance to be a child of the ball
    //     arrowInstance.transform.parent = transform;

    //     // Disable the arrow instance's collider so it doesn't interfere with the ball's movement
    //     arrowInstance.GetComponent<Collider2D>().enabled = false;
    // }

    // private void Update()
    // {
    //     // Check if the ball is currently being dragged by the arrow
    //     if (Input.GetMouseButton(0) && transform.childCount > 0)
    //     {
    //         // Get the arrow instance and calculate the direction to move the ball
    //         GameObject arrowInstance = transform.GetChild(0).gameObject;
    //         direction = arrowInstance.transform.position - transform.position;

    //         // Move the ball in the calculated direction at the set speed
    //         transform.position += direction.normalized * speed * Time.deltaTime;
    //     }
    //     else
    //     {
    //         // If the ball is not being dragged by the arrow, destroy the arrow instance
    //         if (transform.childCount > 0)
    //         {
    //             Destroy(transform.GetChild(0).gameObject);
    //         }
    //     }
    // }


}





