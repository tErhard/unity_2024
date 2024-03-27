using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float radius = 5f;
    public float speed = 2f;
    private float angle = 0f;
    void Update()
    {
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, 5f, z);

        angle += speed * Time.deltaTime;

        if (angle >= 360f)
        {
            angle -= 360f;
        }
    }
}
