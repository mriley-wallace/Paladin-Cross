using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;


    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    public Animator animator;


    [SerializeField] private float jumpHeight;

    //references
    [SerializeField] private CharacterController controller;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= walkSpeed;
        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                //walking
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                //running
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                //idling
                Idle();
            }

            

            if (Input.GetKeyDown(KeyCode.Space))
            {
               Jump();
                

            }


            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
            }

            else
            {
                animator.SetBool("isAttacking", false);
            }
            moveDirection *= moveSpeed;
        }

        

        controller.Move(moveDirection * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    private void Walk()
    {
        moveSpeed = walkSpeed;
        animator.SetBool("isWalking", true);

    }

    private void Run()
    {
        moveSpeed = runSpeed;
        animator.SetBool("isShiftPressed", true);
    }

    private void Idle()
    {

    }

    private void Jump()
    {
        
        velocity.y = Mathf.Sqrt(jumpHeight * -3 * gravity);
        animator.SetBool("isWalking", false);
        animator.SetBool("isShiftPressed", false);
        animator.SetBool("isJumping", true);


    }

    private void Attack()
    {
        animator.SetBool("isAttacking", true);

    }
}
