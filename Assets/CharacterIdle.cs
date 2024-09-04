using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdle : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        VfxManager.Instance.SetEffectState(2, true);
    }
}
