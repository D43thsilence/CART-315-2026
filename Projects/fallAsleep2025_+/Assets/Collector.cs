using System;
using System.Threading;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public float xLoc, yLoc = 0;
    // Sets the player's speed
    public float speed = 5f;
    // Sets the speed of the player's vertical movement
    public float yMovement = 5f;
    // Sets the maximum height of the player can be at
    public float maxHeight = 0f;
    // Sets the minimum height of the player can be at
    public float minHeight = -4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // xLoc = 0;
        // yLoc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
            // update the variable
            xLoc -= speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            // update the variable
            xLoc += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W) && yLoc <= maxHeight)
        {
            Debug.Log("Up");
            // update the variable
            yLoc = yLoc + yMovement * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && yLoc >= minHeight)
        {
            Debug.Log("Down");
            // update the variable
            yLoc = yLoc - yMovement * Time.deltaTime;
        }
        // Update the position
        this.transform.position = new Vector3(xLoc, yLoc, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Circle")
        {
            Destroy(other.gameObject);
        }
    }
}
