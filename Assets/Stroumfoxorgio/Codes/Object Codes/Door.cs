using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;

    public void openDoor()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsOpen", true);
    }

    public void closeDoor()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsOpen", false);
    }
}
