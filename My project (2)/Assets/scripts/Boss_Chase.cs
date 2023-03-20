using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Chase : StateMachineBehaviour
{
   
    Transform player;
    Rigidbody2D rb;
    BossBehavior bossBehavior;
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo StateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        bossBehavior = animator.GetComponent<BossBehavior>();

    }

    // Update is called once per frame
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo StateInfo, int layerIndex)
    {
        bossBehavior.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newpos = Vector2.MoveTowards(rb.position, target, bossBehavior.speed * Time.deltaTime);
        rb.MovePosition(newpos);
        float distance = Vector2.Distance(player.position, rb.position);

        if(distance <bossBehavior.attackRange && !bossBehavior.phase2 && !bossBehavior.phase3 && !bossBehavior.isDead)
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
}
