using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceChecker : MonoBehaviour
{
    GameObject player;
    public LayerMask PlayerMask;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform);

        Vector3 direction = (player.transform.position - transform.position);
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.RotateTowards(transform.forward, direction, 100, 0.0f));
        Debug.DrawLine(ray.origin, ray.direction);

        if (Physics.Raycast(ray, out hit, float.PositiveInfinity, PlayerMask))
        {
            Debug.Log(hit.distance);
        }

        //float distance = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(Mathf.Round(distance)); 
    }
}
