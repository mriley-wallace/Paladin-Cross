using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        //QualitySettings.vSyncCount = 0;  // VSync must be disabled
        //Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") != 0  && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isShiftPressed", false);
        }
        else if(Input.GetAxis("Vertical") != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isShiftPressed", true);
        } 
        else if (Input.GetAxis("Horizontal") != 0 && !Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isShiftPressed", false);
        }
        else if(Input.GetAxis("Vertical") != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isShiftPressed", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isShiftPressed", false);
           
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
