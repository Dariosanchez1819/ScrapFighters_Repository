using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        //Attack
        attackIndex = 1;
        duration = 0.5f;
        animator.SetTrigger("Attack" + attackIndex);
    //    Debug.Log("Player Attack " + attackIndex + " Fired!");
    }

    public override void OnUpdate(char type)
    {
        base.OnUpdate(type);
        if (fixedtime >= duration)
        {
            if (shouldCombo)
            {
            //    Debug.Log("2");
                stateMachine.SetNextState(new IdleCombatState());
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
    }
}
