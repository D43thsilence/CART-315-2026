using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScriptRight : MonoBehaviour
{
    private float yPos;
    public float paddleSpeed = .05f;

    public KeyCode upKey, downKey;
    public float topWall, bottomWall;

    public static PaddleScriptRight R;

    void Awake()
    {
        R = this;
    }
    public void ChangeSpeed(float newSpeed)
    {
        float _newSpeed = newSpeed;

        paddleSpeed = _newSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeSpeed(0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed(paddleSpeed);
        if (Input.GetKey(downKey) && yPos > bottomWall)
        {
            yPos -= paddleSpeed;
        }

        if (Input.GetKey(upKey) && yPos < topWall)
        {
            yPos += paddleSpeed;
        }

        transform.localPosition = new Vector3(transform.position.x, yPos, 0);
    }

}

