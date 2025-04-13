using System.Collections.Generic;
using UnityEngine;

public class SoundRun : MonoBehaviour

{
    public AudioSource footstepsSound; // ���� �����

    // ���������� ������ ����
    void Update()
    {
        // �������� �������� ��� ��������������� �������� ���������
        float horizontalInput = Input.GetAxis("Horizontal");

        // ���������, ������ �� ��� ��������������� ��������
        if (horizontalInput != 0)
        {
            // ������������� ���� �����
            if (!footstepsSound.isPlaying)
            {
                footstepsSound.Play();
            }
        }
        else
        {
            // ������������� ���� �����, ���� ��� �� ������
            footstepsSound.Stop();
        }
    }
}