using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Move : MonoBehaviour
{
    // Normal Movements Variables
    private float curSpeed;
    private float maxSpeed;

    public Rigidbody2D Body;

    public float speed;

    void Start()
    {
        Application.targetFrameRate = 100;
    }

    void FixedUpdate()
    {
        maxSpeed = curSpeed;
        
        float mH = Input.GetAxis("P1_Horizontal");
        float mV = Input.GetAxis("P1_Vertical");
        Body.velocity = new Vector2(mH * speed, mV * speed);
    }
}
