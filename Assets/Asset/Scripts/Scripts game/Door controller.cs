using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedDoorController : MonoBehaviour
{
    public AudioClip openDoorSound; // ���� �������� �����
    public AudioClip closeDoorSound; // ���� �������� �����
    public AudioClip lockedDoorSound; // ���� ��������������� �����
    public float doorOpenSpeed = 2f; // �������� �������� �����

    private AudioSource audioSource;
    private Animator animator;
    private bool isLocked = true; // ����� ���������� �������������
    private bool isOpen = false; // ����� ���������� �������

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // ���������, ������ �� ������� "E"
        {
            TryToggleDoor();
        }
    }

    void TryToggleDoor()
    {
        if (isLocked)
        {
            PlayLockedSound(); // ���� ����� �������������, ������������� ����
        }
        else
        {
            if (isOpen)
            {
                CloseDoor(); // ��������� �����
            }
            else
            {
                OpenDoor(); // ��������� �����
            }
        }
    }

    void OpenDoor()
    {
        animator.SetBool("isOpen", true); // ��������� �������� ��������
        audioSource.PlayOneShot(openDoorSound); // ������������� ���� ��������
        isOpen = true;
        Debug.Log("����� �������!");
    }

    void CloseDoor()
    {
        animator.SetBool("isOpen", false); // ��������� �������� ��������
        audioSource.PlayOneShot(closeDoorSound); // ������������� ���� ��������
        isOpen = false;
        Debug.Log("����� �������!");
    }

    void PlayLockedSound()
    {
        audioSource.PlayOneShot(lockedDoorSound); // ������������� ���� ��������������� �����
        Debug.Log("����� �������������!");
    }

    // ����� ��� ������������� ����� (����� �������� �� ������� �������)
    public void UnlockDoor()
    {
        isLocked = false;
        Debug.Log("����� ��������������!");
    }

    // ����� ��� ���������� ����� (����� �������� �� ������� �������)
    public void LockDoor()
    {
        isLocked = true;
        Debug.Log("����� �������������!");
    }
}


