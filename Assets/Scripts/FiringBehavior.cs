using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBehavior : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        VfxManager.Instance.DisableChannellingVfx(); 
        ProjectileSpawner.Instance.DelayProjectile(); 
    }
}
