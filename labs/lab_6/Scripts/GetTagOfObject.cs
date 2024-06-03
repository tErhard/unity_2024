using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTagOfObject : MonoBehaviour
{
    public LayerMask mask;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10000f, mask))
            {
                Debug.Log(hit.collider.gameObject.tag);
                
            }
            Debug.DrawRay(ray.origin, ray.direction);
        }
    }
}
