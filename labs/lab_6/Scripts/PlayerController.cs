using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private bool sprint = false;
    private float vectorMaxMagnitude = 0.5f;
    public float rotationSpeed = 10.0f;
    public float speed = 2.5f;

    public Transform groundCheckerTransform;
    public LayerMask notPlayerMask;
    public float jumpForce = 5f;


    private float minusFloat = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 directionVector = new Vector3 (x, 0, z);
        if (directionVector.magnitude > Mathf.Abs(0.05f))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (!sprint)
                {
                    sprint = true;
                    speed *= 1.5f;
                    jumpForce *= 1.5f;
                }
                if(vectorMaxMagnitude < 1.0f)
                {
                    vectorMaxMagnitude += 0.015f;
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                sprint = false;
                speed /= 1.5f;
                jumpForce /= 1.5f;
            }
            if(!sprint)
            {
                if(vectorMaxMagnitude > 0.5f)
                {
                    vectorMaxMagnitude -= 0.01f;
                }
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-directionVector), Time.deltaTime * rotationSpeed);

            animator.SetFloat("speed", Vector3.ClampMagnitude(directionVector, vectorMaxMagnitude).magnitude);
            Vector3 moveDir = Vector3.ClampMagnitude(directionVector, vectorMaxMagnitude) * speed;
            rb.velocity = new Vector3(-moveDir.x, rb.velocity.y, -moveDir.z);
            rb.angularVelocity = Vector3.zero;
            minusFloat = animator.GetFloat("speed");
        }
        else
        {
            if(animator.GetFloat("speed") > 0)
            {
                animator.SetFloat("speed", minusFloat);
                minusFloat -= 0.013f;
            }
            else
            {
                animator.SetFloat("speed", 0.0f);
            }
            
            if (sprint)
            {
                sprint = false;
                vectorMaxMagnitude = 0.5f;
                speed /= 1.5f;
                jumpForce /= 1.5f;
            }
            
        
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Physics.CheckSphere(groundCheckerTransform.position, 0.2f, notPlayerMask))
        {
            animator.SetBool("isInAir", false);
        }
        else
        {
            animator.SetBool("isInAir", true);
        }
    }
    void Jump()
    {
        if (Physics.Raycast(groundCheckerTransform.position, Vector3.down, 0.2f, notPlayerMask))
        {
            animator.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void SetZero()
    {
        speed = 0.0f;
        jumpForce = 0.0f;
        rotationSpeed = 0.0f;
    }
}
