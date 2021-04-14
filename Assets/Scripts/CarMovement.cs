using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody carRb;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 eulerAngleVelocity;
    private Transform carTransform;
    private RaycastHit rayHit;
    private bool isGrounded;
    private bool canRotate;

    private void Awake()
    {
        carTransform = transform;
    }

    void Start()
    {
       eulerAngleVelocity = new Vector3(0,0, rotationSpeed);
    }
    
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (isGrounded)
            {
                carRb.AddForce(carTransform.right * (movementSpeed * Time.fixedDeltaTime));
            }
            else if (canRotate)
            {
                //Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
                //carRb.MoveRotation(carRb.rotation * deltaRotation);
                carRb.AddTorque(-carTransform.up * rotationSpeed);
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        canRotate = false;
    }

    private void OnTriggerExit(Collider other)
    {
        canRotate = true;
    }
}
