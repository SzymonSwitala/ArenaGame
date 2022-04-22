using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeFall : StateMachineBehaviour
{
    KingSlime kingSlime; 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        kingSlime = animator.GetComponent<KingSlime>();
        int random = Random.Range(0,2);
        if (random==0)
        {

            animator.transform.position = GameManager.Instance.player.transform.position;
        }
        else
        {
            animator.transform.position = kingSlime.GetRandomJumpPosition();
        }
       

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        kingSlime.Shoot(0);

    }

}
