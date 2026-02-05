using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class BallScript : MonoBehaviour
{
    // THIS BALL IS ALL POWERFUL IT CONTROLS TIME, SPACE, AND SCORING

    public float ballSpeed = 20;
    private int[] directionOptions = { -1, 1 };
    private int hDir, vDir;
    public int score1, score2;
    public AudioSource blip;
    private Rigidbody2D rb;
    private float state = 0;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public GameObject topWall;
    public GameObject bottomWall;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Reset();
    }

    private void OnCollisionEnter2D(Collision2D wall)
    {

        if (wall.gameObject.name == "leftWall")
        {
            // give points to Player 2
            score2 += 1;
            Reset();
        }
        if (wall.gameObject.name == "rightWall")
        {
            // give points to Player 1
            score1 += 1;
            Reset();
        }

        if (wall.gameObject.name == "topWall" || wall.gameObject.name == "bottomWall")
        {
            blip.pitch = 0.75f;
            blip.Play();
            // blip.pitch = 1;
        }

        if (wall.gameObject.name == "paddleLeft" || wall.gameObject.name == "paddleRight")
        {
            blip.pitch = 1f;
            blip.Play();
        }
    }

    private IEnumerator Launch()
    {
        // choose Random X dir
        hDir = directionOptions[Random.Range(0, directionOptions.Length)];
        // choose Random Y dir
        vDir = directionOptions[Random.Range(0, directionOptions.Length)];
        // Random.Range(0, directionOptions.Length);

        // wait for X seconds
        yield return new WaitForSeconds(1);

        // Apply Force
        // Horizontal
        rb.AddForce(transform.right * ballSpeed * hDir);
        // Vertical 
        rb.AddForce(transform.up * ballSpeed * vDir);
    }

    void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        this.transform.localPosition = new Vector3(0, 0, 0);
        RandomState();
        // Launch
        StartCoroutine(Launch());
    }

    void RandomState()
    {
        state = Random.Range(0, 7);

        if (state == 1)
        {
            ballSpeed = 60;
            leftPaddle.transform.localPosition = new Vector3(-8, 0, 0);
            rightPaddle.transform.localPosition = new Vector3(8, 0, 0);
            leftPaddle.transform.localScale = new Vector3(1, 1, 1);
            rightPaddle.transform.localScale = new Vector3(1, 1, 1);
            topWall.transform.position = new Vector3(0, 5.5f, 0);
            bottomWall.transform.position = new Vector3(0, -5.5f, 0);
            float newSpeed = 0.05f;
            PaddleScript.L.ChangeSpeed(newSpeed);
            PaddleScriptRight.R.ChangeSpeed(newSpeed);
        }

        if (state == 2)
        {
            ballSpeed = 20;
            leftPaddle.transform.localPosition = new Vector3(-5, 0, 0);
            rightPaddle.transform.localPosition = new Vector3(5, 0, 0);
            leftPaddle.transform.localScale = new Vector3(1, 1, 1);
            rightPaddle.transform.localScale = new Vector3(1, 1, 1);
            topWall.transform.position = new Vector3(0, 5.5f, 0);
            bottomWall.transform.position = new Vector3(0, -5.5f, 0);
            float newSpeed = 0.05f;
            PaddleScript.L.ChangeSpeed(newSpeed);
            PaddleScriptRight.R.ChangeSpeed(newSpeed);
        }

        if (state == 3)
        {
            ballSpeed = 20;
            leftPaddle.transform.localPosition = new Vector3(-8, 0, 0);
            rightPaddle.transform.localPosition = new Vector3(8, 0, 0);
            leftPaddle.transform.localScale = new Vector3(1, 1, 1);
            rightPaddle.transform.localScale = new Vector3(1, 1, 1);
            topWall.transform.position = new Vector3(0, 5.5f, 0);
            bottomWall.transform.position = new Vector3(0, -5.5f, 0);
            float newSpeed = 0.007f;
            PaddleScript.L.ChangeSpeed(newSpeed);
            PaddleScriptRight.R.ChangeSpeed(newSpeed);
        }

        if (state == 4)
        {
            ballSpeed = 20;
            topWall.transform.position = new Vector3(0, 4.5f, 0);
            bottomWall.transform.position = new Vector3(0, -4.5f, 0);
            leftPaddle.transform.localPosition = new Vector3(-8, 0, 0);
            rightPaddle.transform.localPosition = new Vector3(8, 0, 0);
            leftPaddle.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            rightPaddle.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            float newSpeed = 0.05f;
            PaddleScript.L.ChangeSpeed(newSpeed);
            PaddleScriptRight.R.ChangeSpeed(newSpeed);
        }

        if (state == 5)
        {
            ballSpeed = 60;
            leftPaddle.transform.localPosition = new Vector3(-8, 0, 0);
            rightPaddle.transform.localPosition = new Vector3(8, 0, 0);
            leftPaddle.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            rightPaddle.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            topWall.transform.position = new Vector3(0, 5.5f, 0);
            bottomWall.transform.position = new Vector3(0, -5.5f, 0);
            float newSpeed = 0.05f;
            PaddleScript.L.ChangeSpeed(newSpeed);
            PaddleScriptRight.R.ChangeSpeed(newSpeed);
        }

        if (state == 6)
        {
            ballSpeed = 20;
            leftPaddle.transform.localPosition = new Vector3(-5, 0, 0);
            rightPaddle.transform.localPosition = new Vector3(5, 0, 0);
            leftPaddle.transform.localScale = new Vector3(1, 1, 1);
            rightPaddle.transform.localScale = new Vector3(1, 1, 1);
            topWall.transform.position = new Vector3(0, 5.5f, 0);
            bottomWall.transform.position = new Vector3(0, -5.5f, 0);
            float newSpeed = 0.007f;
            PaddleScript.L.ChangeSpeed(newSpeed);
            PaddleScriptRight.R.ChangeSpeed(newSpeed);
        }
    }
}
