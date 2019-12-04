using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public Controllable controllable;
    public GameObject mainCam;
    public Animator anim;

    private Vector2 axis;
    private float joystickMag;

    public float speed = 0;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
       controllable = GetComponent<Controllable>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!controllable.lockMovement && !isDead)
        {
            axis.x = Input.GetAxis("Horizontal");
            axis.y = Input.GetAxis("Vertical");
            joystickMag = axis.magnitude;
            anim.SetFloat("InputMag", joystickMag);

            if (joystickMag >= 0.1f)
            {
                float dirAngle = Vector2.SignedAngle(Vector2.up, new Vector2(axis.x, axis.y));
                Vector3 forwardXZ = new Vector3(mainCam.transform.forward.x, 0, mainCam.transform.forward.z);
                Vector3 lookDir = Quaternion.Euler(0, -dirAngle, 0) * forwardXZ;

                float angleDiff = Vector3.SignedAngle(lookDir, transform.forward, Vector3.up);
                float angleNorm = angleDiff / 180f;

                if (lookDir.magnitude > 0)
                {
                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDir), 5 * Time.deltaTime);
                }
               // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angleDiff, transform.forward), 1);
                transform.position += transform.forward * speed * joystickMag * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Arrow>())
        {
            anim.SetTrigger("Die");
            isDead = true;
        }
    }
}
