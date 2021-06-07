using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;
    [SerializeField] private float mouseSensitivity;

    private void Start()
    {
        target = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
    }

    //private void FixedUpdate()
    //{
    //    Vector3 desirePosition = target.position + offset;
    //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed * Time.deltaTime);
    //    transform.position = smoothedPosition;

    //}

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        target.Rotate(Vector3.up, mouseX);

    }
}
