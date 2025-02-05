using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedDoorController : MonoBehaviour
{
    public AudioClip openDoorSound; // Звук открытия двери
    public AudioClip closeDoorSound; // Звук закрытия двери
    public AudioClip lockedDoorSound; // Звук заблокированной двери
    public float doorOpenSpeed = 2f; // Скорость открытия двери

    private AudioSource audioSource;
    private Animator animator;
    private bool isLocked = true; // Дверь изначально заблокирована
    private bool isOpen = false; // Дверь изначально закрыта

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Проверяем, нажата ли клавиша "E"
        {
            TryToggleDoor();
        }
    }

    void TryToggleDoor()
    {
        if (isLocked)
        {
            PlayLockedSound(); // Если дверь заблокирована, воспроизводим звук
        }
        else
        {
            if (isOpen)
            {
                CloseDoor(); // Закрываем дверь
            }
            else
            {
                OpenDoor(); // Открываем дверь
            }
        }
    }

    void OpenDoor()
    {
        animator.SetBool("isOpen", true); // Запускаем анимацию открытия
        audioSource.PlayOneShot(openDoorSound); // Воспроизводим звук открытия
        isOpen = true;
        Debug.Log("Дверь открыта!");
    }

    void CloseDoor()
    {
        animator.SetBool("isOpen", false); // Запускаем анимацию закрытия
        audioSource.PlayOneShot(closeDoorSound); // Воспроизводим звук закрытия
        isOpen = false;
        Debug.Log("Дверь закрыта!");
    }

    void PlayLockedSound()
    {
        audioSource.PlayOneShot(lockedDoorSound); // Воспроизводим звук заблокированной двери
        Debug.Log("Дверь заблокирована!");
    }

    // Метод для разблокировки двери (можно вызывать из другого скрипта)
    public void UnlockDoor()
    {
        isLocked = false;
        Debug.Log("Дверь разблокирована!");
    }

    // Метод для блокировки двери (можно вызывать из другого скрипта)
    public void LockDoor()
    {
        isLocked = true;
        Debug.Log("Дверь заблокирована!");
    }
}


