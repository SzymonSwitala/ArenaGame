using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeJump : StateMachineBehaviour
{
    KingSlime kingSlime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        kingSlime = animator.GetComponent<KingSlime>();
        kingSlime.SpawnSlimes();

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
   

    }
   

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      


    }
}
