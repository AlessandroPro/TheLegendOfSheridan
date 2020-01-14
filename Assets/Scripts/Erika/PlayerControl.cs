﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    
    public float health = 100;
    public GameObject pauseMenu;
    public float rotationSpeed = 1.0f;

    [System.NonSerialized]
    public bool isPaused = false;

    private Rigidbody rb;
    private CapsuleCollider col;
    public Animator anim;
    public AnimatorOverrideController animOverrideController;
    private Transform cameraTransform;
    private Controllable controllable;

    [SerializeField] private Vector2 axis;
    [SerializeField] private float movingTurnSpeed = 360;
    private Vector3 camForward;
    private float stationaryTurnSpeed = 180;
    private float axisMag;
    private Vector3 movement;
    private float turnAmount;
    private float forwardAmount;

    public SkinnedMeshRenderer meshRend;
    public Material[] DamageMats;
    bool hit = false;

    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        controllable = GetComponent<Controllable>();
        cameraTransform = Camera.main.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if(!controllable.lockMovement)
        {
            PlayerMovement();
        }
        if(Input.GetButtonDown("Start Button"))
        {
            isPaused = !isPaused;
            switch (isPaused)
            {
                case true:
                    Time.timeScale = 0.0f;
                    pauseMenu.SetActive(true);
                    break;

                case false:
                    Time.timeScale = 1.0f;
                    pauseMenu.SetActive(false);
                    break;

            }
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy_Weapon>() != null)
        {
            health -= other.gameObject.GetComponent<Enemy_Weapon>().damage;
            StartCoroutine(ShowDamage());
            if(health <= 0)
            {
                Die();
            }
        }
    }

    private IEnumerator ShowDamage()
    {
        if(!hit)
        {
            hit = true;
            var DefaultMats = meshRend.materials;
            meshRend.materials = DamageMats;
            yield return new WaitForSeconds(0.5f);
            meshRend.materials = DefaultMats;
            hit = false;
        }

    }

    private void Respawn()
    {
        controllable.lockInteraction = false;
        controllable.lockMovement = false;
    }

    private void Die()
    {
        controllable.lockInteraction = true;
        controllable.lockMovement = true;
        anim.SetBool("Die", true);
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameOver");
    }
}
