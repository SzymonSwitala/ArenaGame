using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeIdle : StateMachineBehaviour
{
    float timer;
    
    KingSlime kingSlime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RandomTimer();
        kingSlime = animator.GetComponent<KingSlime>();

    }
    
    void RandomTimer()
    {
        timer = Random.Range(2, 4);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       

        if (timer<0)
        {
            int random = Random.Range(0, 2);
            if (random==0)
            {
                RandomTimer();
                animator.SetTrigger("Jump");
            }
            else
            {
                RandomTimer();
                kingSlime.Shoot(30);
                kingSlime.Shoot(0);

            }
           
        }
        else
        {
            timer -= Time.deltaTime;
        }
      
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.ResetTrigger("Jump");
     
    }
}
