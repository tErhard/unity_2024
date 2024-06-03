using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider col)
    {
        animator.SetTrigger("Jump");
    }
}
