using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationController : StateMachineBehaviour
{
    private bool hasTriggered = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!hasTriggered)
        {
            PlantGrowth plantGrowth = animator.gameObject.GetComponent<PlantGrowth>();
            plantGrowth.canGrow = true;
            hasTriggered = true;
        }
    }
}
 
