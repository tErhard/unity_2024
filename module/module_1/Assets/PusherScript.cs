using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float fallSpeed = 5f;
    private bool isFalling = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFalling)
        {
            isFalling = true;
        }

        if (isFalling)
        {
            Vector3 newPosition = transform.position;
            newPosition.y -= fallSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }
}
