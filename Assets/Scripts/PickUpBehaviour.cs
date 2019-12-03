using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehaviour : StateMachineBehaviour
{
    [Header("debug curve info")]
    public float IKRamp;
    private IKControl ikc;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ikc = animator.gameObject.GetComponent<IKControl>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if this clip has IkRamp curve, then apply it to the IKHandler component 
        // on the gameObject that has the animator that is playing this state
       
        //IKRamp = animator.GetFloat("IKRamp");
        //if (ikc != null)
        //{
        //    ikc.setWeight(IKRamp);
        //}

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //ikc.getWeightFromAnim = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}