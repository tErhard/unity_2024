using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    float speed = 1.0f;
    public LayerMask enemyMask;

    public GameObject fireBallPrefab;
    public Transform fireBallSpawn;
    public float fireBallSpeed = 8f;
    GameObject fireBall;

    float attackDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, enemyMask))
            {
                agent.destination = transform.position;
                animator.SetFloat("Speed", 0.0f);
                agent.
                transform.LookAt(hit.point);

                animator.SetTrigger("Attack");
                Invoke(nameof(Attack), attackDelay);
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                speed = 1.0f;
                agent.destination = hit.point;
                animator.SetFloat("Speed", 1.0f);
            }

        }
        if (agent.nextPosition == agent.destination)
        {
            if (speed > 0)
            {
                speed -= 0.1f;
                animator.SetFloat("Speed", speed);
            }

        }
    }

    void Attack()
    {
        fireBall = Instantiate(fireBallPrefab, fireBallSpawn.position, Quaternion.identity);
        fireBall.GetComponent<Rigidbody>().AddForce(fireBallSpawn.forward * fireBallSpeed, ForceMode.Impulse);
    }
}
