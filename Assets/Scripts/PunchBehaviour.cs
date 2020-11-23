using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBehaviour : StateMachineBehaviour
{

    [SerializeField] [Range(0.0f, 1.0f)] float punchStartTime;
    [SerializeField] [Range(0.0f, 1.0f)] float punchEndTime;
    [SerializeField] AttackController attack;
    [SerializeField] AttackController.PunchType punchType;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attack = animator.GetComponent<AttackController>();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        bool isActive = animatorStateInfo.normalizedTime > punchStartTime && animatorStateInfo.normalizedTime < punchEndTime;
        attack.updatePunch(punchType, isActive);
    }
}
