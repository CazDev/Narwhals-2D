using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_Damage : MonoBehaviour
{

    public int damage;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player2"))
        {
            P2_PlayerHealth.Instance.TakeDamage(damage, true);
        }
    }
}
