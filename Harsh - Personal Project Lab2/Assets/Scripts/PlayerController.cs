using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 80.0f;
    private float zUpperBound = 12;
    private float zLowerBound = 0;

    private Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    //Move the player based on user input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    //Prevent the player in top and bottom position
    void ConstrainPlayerPosition()
    {
        if (transform.position.z > zUpperBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zUpperBound);
        }
        if (transform.position.z < zLowerBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLowerBound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Enemy");
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Collided with Powerup");
            Destroy(other.gameObject);
        }
    }
}
