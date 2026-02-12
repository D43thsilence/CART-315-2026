using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BrickScript : MonoBehaviour
{
    public int pointValue = 1;
    public float movementSpeed = 5;
    public float initialMovement;
    public Boolean initializeMovement = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.initialMovement = Random.Range(-1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        initializedMovement();
        // If the obstacle moves beyond a certain range, inverts the movement speed to enable it to move back and forth
        if (this.transform.position.x <= -10)
        {
            movementSpeed = -movementSpeed;
        }

        if (this.transform.position.x >= 10)
        {
            movementSpeed = -movementSpeed;
        }

        // Makes the brick move
        this.transform.position = this.transform.position + (new Vector3(movementSpeed, 0, 0) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Brick")
        {
            // movementSpeed = -movementSpeed;
            // this.pointValue = pointValue++;
        }
    }

    private void initializedMovement()
    {
        if (initialMovement > 0 && initializeMovement == false)
        {
            this.movementSpeed = Random.Range(1, 5);
            initializeMovement = true;
        }
        else if (initialMovement == 0 && initializeMovement == false)
        {
            this.movementSpeed = Random.Range(-1, -5);
            initializeMovement = true;
        }
        else if (initialMovement < 0 && initializeMovement == false)
        {
            this.movementSpeed = Random.Range(-1, -5);
            initializeMovement = true;
        }
    }
}
