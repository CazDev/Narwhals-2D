using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float maxSpeed;
    public GameObject target;
    public Rigidbody2D body;
    public float accuracy = 0.4f;
    public Vector2 RandPoint;
    private float UpdateRate = 0.3f;
    private float MoveUpdateRate = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
    }

    float elapsed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= UpdateRate)
        {
            elapsed = elapsed % UpdateRate;
            UpdateRate = Random.Range(0.4f, 0.8f);

            //Random interval code
            RandPoint = new Vector2(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy));
            speed = Random.Range(1.2f, maxSpeed);
            OutputTime();
        }
        
        if (elapsed >= 0.02f)
        {
            elapsed = elapsed % 0.02f;

            //Random interval code

            OutputTime();

            Vector2 newPosition = Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.x + RandPoint.x, target.transform.position.y + RandPoint.y), Time.fixedDeltaTime * speed);
            body.MovePosition(newPosition);
        }
    }

    void OutputTime()
    {
        Debug.Log(Time.time);
    }
}