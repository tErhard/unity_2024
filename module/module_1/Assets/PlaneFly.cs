using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public float radius = 5f; // Радіус кола
    public float speed = 2f; // Швидкість руху по колу
    private float angle = 0f; // Кут, на який об'єкт повернутий

    void Update()
    {
        // Обчислюємо нові координати об'єкта на колі
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Встановлюємо нові координати об'єкта
        transform.position = new Vector3(x, 5f, z);

        // Збільшуємо кут для наступного кадру
        angle += speed * Time.deltaTime;

        // Якщо кут стає більшим за 360 градусів, то повертаємо його назад
        if (angle >= 360f)
        {
            angle -= 360f;
        }
    }
}
