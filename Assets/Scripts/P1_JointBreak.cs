using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1_JointBreak : MonoBehaviour
{

    void OnJointBreak2D()
    {
        P1_PlayerHealth.Instance.TakeDamage(25, false);
    }
}
