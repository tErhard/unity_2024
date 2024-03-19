using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float fallSpeed = 5f; // Швидкість падіння об'єкту
    private bool isFalling = false; // Прапорець, який показує, чи об'єкт падає

    void Update()
    {
        // Перевірка, чи натиснуто клавішу пробілу і об'єкт не падає вже
        if (Input.GetKeyDown(KeyCode.Space) && !isFalling)
        {
            isFalling = true; // Встановлення прапорця, що об'єкт падає
        }

        // Якщо об'єкт падає, змінюємо його позицію по осі Y
        if (isFalling)
        {
            // Визначаємо нову позицію об'єкту
            Vector3 newPosition = transform.position;
            newPosition.y -= fallSpeed * Time.deltaTime; // Рухаємо об'єкт вниз зі швидкістю fallSpeed

            // Присвоюємо нову позицію об'єкту
            transform.position = newPosition;
        }
    }
}
