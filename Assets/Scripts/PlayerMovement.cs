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

    //references
    private CharacterController controller;


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
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection *= walkSpeed;

        if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            //walking
        }
        else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            //running
        }
        else if(moveDirection == Vector3.zero)
        {
            //idling
        }

        controller.Move(moveDirection * Time.deltaTime);
    }
}
