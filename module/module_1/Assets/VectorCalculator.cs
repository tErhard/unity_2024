using UnityEngine;

public class AngleCalculator : MonoBehaviour
{
    void Start()
    {
        Vector3 vector1 = new Vector3(1, 5, -7);
        Vector3 vector2 = new Vector3(1, 8, -1);

        float angle = Vector3.Angle(vector1, vector2);

        Debug.Log("Кут між векторами: " + angle + " градусів");
    }
}
