﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    private Rigidbody rb;
    private CapsuleCollider col;
    private Animator anim;
    private Transform cameraTransform;

    [SerializeField] private Vector2 axis;
    [SerializeField] private float movingTurnSpeed = 360;
    private Vector3 camForward;
    private float stationaryTurnSpeed = 180;
    private float axisMag;
    private Vector3 movement;
    private float turnAmount;
    private float forwardAmount;

    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");
        axisMag = axis.magnitude;

        anim.SetFloat("InputX", axis.x);
        anim.SetFloat("InputY", axis.y);
        anim.SetFloat("InputMag", axisMag);

        axis.Normalize();

        camForward = cameraTransform.forward;
        camForward.y = 0;
        camForward = camForward.normalized;

        movement = axis.y * camForward + axis.x * cameraTransform.right;
        if(movement.magnitude > 1.0f)
        {
            movement.Normalize();
        }
        movement = transform.InverseTransformDirection(movement);
        movement = Vector3.ProjectOnPlane(movement, transform.up);
        turnAmount = Mathf.Atan2(movement.x, movement.z);
        forwardAmount = movement.z;
        ApplyExtraTurnRotation();
        
        UpdateAnimator();
    }

    private void ApplyExtraTurnRotation()
    {
        // help the character turn faster (this is in addition to root rotation in the animation)
        float turnSpeed = Mathf.Lerp(stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
        transform.Rotate(0, turnAmount * turnSpeed * Time.deltaTime, 0);
    }

    private void UpdateAnimator()
    {
        anim.SetFloat("Forward", forwardAmount, 0.1f, Time.deltaTime);
        anim.SetFloat("Turn", turnAmount, 0.1f, Time.deltaTime);
    }
}
