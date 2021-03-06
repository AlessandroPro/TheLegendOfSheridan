﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rider : MonoBehaviour
{
    public Rideable availableRide;
    private Rideable mountedRide;

    private Controllable controllable;
    private IKControl ikc;
    public Animator anim;
    private CapsuleCollider col;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ikc = GetComponent<IKControl>();
        controllable = GetComponent<Controllable>();
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controllable.lockInteraction)
        {
            if (Input.GetButtonDown("Triangle Button"))
            {
                if(mountedRide)
                {
                    Dismount();
                }
                else if(availableRide)
                {
                    Mount();
                }
            }
        }
    }

    void Mount()
    {
        if (availableRide)
        {
            Rideable ride = availableRide;
            availableRide = null;

            AnimationClip[] mountClips = ride.mountClips;

            // Set the IK goals for left and right hands and feet for the rideable
            ikc.trackObjRH = ride.rightHandle;
            ikc.trackObjLH = ride.leftHandle;
            ikc.trackObjRF = ride.rightPedal;
            ikc.trackObjLF = ride.leftPedal;
            ikc.lookObj = ride.lookAt.transform;

            anim.SetBool("MirrorAnim", ride.mirrorMount);
            
            if(ride.animStart)
            {
                gameObject.transform.position = ride.animStart.position;
                gameObject.transform.rotation = ride.animStart.rotation;
            }

            rb.isKinematic = true;
            ride.OnMount();

            var animOverrider = new AnimatorOverrideController(anim.runtimeAnimatorController);
            anim.runtimeAnimatorController = animOverrider;

            if (animOverrider && mountClips.Length == 3)
            {
                animOverrider["MountLeft"] = mountClips[0];
                animOverrider["MountIdle"] = mountClips[1];
            }

            anim.SetTrigger("Ride");

            ikc.getWeightFromAnim = true;

            mountedRide = ride;

            controllable.lockMovement = true;
            transform.parent = mountedRide.transform;            
        }
    }

    void Dismount()
    {
        anim.SetTrigger("Ride");
        mountedRide.OnDismount();
        rb.isKinematic = false;
        mountedRide = null;
        ikc.lookObj = null;
        controllable.lockMovement = false;
        transform.parent = null;
    }

    public void setMountCollider()
    {
        //col.enabled = !col.enabled;
        //rb.isKinematic = !rb.isKinematic;
    }
}
