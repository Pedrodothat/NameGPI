using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    BossBehavior bossBehavior;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        bossBehavior = animator.GetComponent<BossBehavior>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         bossBehavior.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newpos = Vector2.MoveTowards(rb.position, target, bossBehavior.speed * Time.deltaTime);
        rb.MovePosition(newpos);
        float distance = Vector2.Distance(player.position, rb.position);

        if (distance < bossBehavior.attackRange && !bossBehavior.phase2 && !bossBehavior.phase3 && !bossBehavior.isDead)
        {
            Debug.Log("hit");
        }
        else if (distance < bossBehavior.attackRange && bossBehavior.phase2 && !bossBehavior.phase3 && !bossBehavior.isDead)
        {

        }
        else if (distance < bossBehavior.attackRange && !bossBehavior.phase2 && bossBehavior.phase3 && !bossBehavior.isDead)
        {

        }
        else if (bossBehavior.isDead)
        {

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

  
}
