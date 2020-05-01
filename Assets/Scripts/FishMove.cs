using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    public SpriteRenderer SR;
    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    bool moveRight = true;
    // Update is called once per frame
    void Update()
    {
        if (RB.position.x < 0.65 && moveRight)
        {
            RB.AddForce(transform.right * 0.5f * Time.deltaTime, ForceMode2D.Impulse);
        }
        else
        {
            moveRight = false;
        }

        if (RB.position.x > 0.65 && !moveRight)
        {
            RB.AddForce(-transform.right * 0.5f * Time.deltaTime, ForceMode2D.Impulse);
        }
        else
        {
            moveRight = true;
        }

        if (RB.velocity.x > 0.01)
        {
            SR.flipX = false;
        }

        if (RB.velocity.x < 0.01)
        {
            SR.flipX = true;
        }

    }
}
