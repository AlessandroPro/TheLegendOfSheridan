using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class IKControl : MonoBehaviour
{
    protected Animator animator;
    public bool ikActive = false;
    public Transform lookObj = null;

    [Header("ik params")]
    public float weight;
    public GameObject trackObjLH;
    public GameObject trackObjRH;
    public GameObject trackObjLF;
    public GameObject trackObjRF;

    public bool getWeightFromAnim = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {
            //if the IK is active, set the position and rotation directly to the goal. 
            if (ikActive)
            {
                if(getWeightFromAnim)
                {
                    weight = animator.GetFloat("IKRamp");
                }

                // Set the look __target position__, if one has been assigned
                if (lookObj != null)
                {
                    animator.SetLookAtWeight(weight);
                    animator.SetLookAtPosition(lookObj.position);
                }

                // Set the right hand target position and rotation, if one has been assigned
                setGoalData(AvatarIKGoal.LeftHand, trackObjLH);
                setGoalData(AvatarIKGoal.RightHand, trackObjRH);
                setGoalData(AvatarIKGoal.LeftFoot, trackObjLF);
                setGoalData(AvatarIKGoal.RightFoot, trackObjRF);
            }

            //if the IK is not active, set the position and rotation of the hand and head back to the original position
            else
            {
                animator.SetLookAtWeight(0);

                resetGoal(AvatarIKGoal.LeftHand);
                resetGoal(AvatarIKGoal.RightHand);
                resetGoal(AvatarIKGoal.LeftFoot);
                resetGoal(AvatarIKGoal.RightFoot);
            }
        }
    }

    void resetGoal(AvatarIKGoal goal)
    {
        animator.SetIKPositionWeight(goal, 0);
        animator.SetIKRotationWeight(goal, 0);
    }

    void setGoalData(AvatarIKGoal goal, GameObject trackObj)
    {
        if (trackObj != null)
        {
            animator.SetIKPositionWeight(goal, weight);
            animator.SetIKRotationWeight(goal, weight);
            animator.SetIKPosition(goal, trackObj.transform.position);
            animator.SetIKRotation(goal, trackObj.transform.rotation);
        }
    }

    public void resetTrackers()
    {
        trackObjLH = null;
        trackObjRH = null;
        trackObjLF = null;
        trackObjRF = null;
        lookObj = null;
    }
}
