using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Die : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider col)
    {
        animator.SetTrigger("isDead");
        Debug.Log("You died");
        FindObjectOfType<PlayerController>().SetZero();
    }
}
