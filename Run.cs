using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : StateMachineBehaviour
{
    private float timer;
    public float minT;
    public float maxT;

    private Transform playerPos;
    private Transform busLook;
    public float speed;
    private int randomNum = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("BusDef3").GetComponent<Transform>();
        busLook = GameObject.FindGameObjectWithTag("BusBos").GetComponent<Transform>();
        timer = Random.Range(minT, maxT);
        randomNum = Random.Range(0, 2);
        //    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0 && randomNum == 0)
        {
            animator.SetTrigger("Jump");
            timer = 0;
        }
        else if (timer <= 0 && randomNum == 1)
        {
            animator.SetTrigger("Attack");
            timer = 0;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        // Vector3 target = new Vector3(playerPos.position, animator.transform.position);
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerPos.position, speed);
        animator.transform.LookAt(busLook);
        //    
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    //    
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
