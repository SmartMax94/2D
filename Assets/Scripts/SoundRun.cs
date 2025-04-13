using System.Collections.Generic;
using UnityEngine;

public class SoundRun : MonoBehaviour

{
    public AudioSource footstepsSound; // Звук шагов

    // Обновление каждый кадр
    void Update()
    {
        // Получаем значение оси горизонтального движения джойстика
        float horizontalInput = Input.GetAxis("Horizontal");

        // Проверяем, нажата ли ось горизонтального движения
        if (horizontalInput != 0)
        {
            // Воспроизводим звук шагов
            if (!footstepsSound.isPlaying)
            {
                footstepsSound.Play();
            }
        }
        else
        {
            // Останавливаем звук шагов, если ось не нажата
            footstepsSound.Stop();
        }
    }
}