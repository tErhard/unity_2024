using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider col)
    {
        animator.SetBool("win", true);
    }
    private void OnTriggerExit(Collider col)
    {
        animator.SetBool("win", false);
    }
}
