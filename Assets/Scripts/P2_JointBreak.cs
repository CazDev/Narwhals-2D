using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_JointBreak : MonoBehaviour
{
    public int damage;

    void OnJointBreak2D()
    {
        P2_PlayerHealth.Instance.TakeDamage(25, false);
    }
}
