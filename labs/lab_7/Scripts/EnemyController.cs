using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    private NavMeshAgent agent;
    [SerializeField] private GameObject target;
    private bool dead = false;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (!dead)
        {
            agent.destination = target.transform.position;
        } 
    }
    private void OnTriggerEnter(Collider other)
    {
        dead = true;
        agent.destination = transform.position;
        animator.SetTrigger("Dead");
        StartCoroutine(WaitForDeath());
    }
    
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
