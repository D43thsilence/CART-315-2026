using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Obstacle : MonoBehaviour
{
    // Sets the movement speed of the obstacle
    public float movementSpeed = 5;
    // Sets the x and y location of the obstacle
    public float xLocation = 0;
    public float yLocation = -2;
    // Sets the text object that displays game over
    public GameObject endText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Makes the obstacles spawn at a random x position
        this.transform.position = new Vector3(UnityEngine.Random.Range(-7, 7), yLocation, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.position + (new Vector3(movementSpeed, 0, 0) * Time.deltaTime);

        // If the obstacle moves beyond a certain range, inverts the movement speed to enable it to move back and forth
        if (this.transform.position.x <= -7.4)
        {
            movementSpeed = -movementSpeed;
        }

        if (this.transform.position.x >= 7.4)
        {
            movementSpeed = -movementSpeed;
        }
    }

    // Destroys the player if it comes in contact with them
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
            Destroy(other.gameObject);
            // Moves the game over text into the camera's bounds
            endText.transform.position = new Vector3(0, 0, 0);
        }
    }
}
