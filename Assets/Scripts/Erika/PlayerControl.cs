using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //for testing UI
    [System.NonSerialized]
    public int health = 100;
    public GameObject pauseMenu;


    [System.NonSerialized]
    public bool isPaused = false;
    //
    public float rotationSpeed = 1.0f;

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

    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        controllable = GetComponent<Controllable>();
        cameraTransform = Camera.main.transform;

        //animOverrideController = new AnimatorOverrideController(anim.runtimeAnimatorController);
        //anim.runtimeAnimatorController = animOverrideController;
    }

    // Update is called once per frame
    void Update()
    {
        if(!controllable.lockMovement)
        {
            PlayerMovement();
            //test ui
            if (health <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
            //
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
        //testing UI
        if (Input.GetButtonUp("pause"))
        {
            if (!isPaused)
            {
                //Debug.Log("pause pressed");
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;

            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }
        }
        //UI
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
