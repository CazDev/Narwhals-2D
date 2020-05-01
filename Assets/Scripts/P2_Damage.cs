using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_Damage : MonoBehaviour
{

    public int damage;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player1"))
        {
            P1_PlayerHealth.Instance.TakeDamage(damage, true);
        }
    }
}
