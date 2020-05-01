using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Move : MonoBehaviour
{
    // Normal Movements Variables
    private float curSpeed;
    private float maxSpeed;

    public Rigidbody2D Body;

    public float speed;

    void FixedUpdate()
    {
        maxSpeed = curSpeed;
        
        float mH = Input.GetAxis("P2_Horizontal");
        float mV = Input.GetAxis("P2_Vertical");
        Body.velocity = new Vector2(mH * speed, mV * speed);
    }
}
