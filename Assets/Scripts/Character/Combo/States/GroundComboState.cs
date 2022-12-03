using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
**		Ground Combo State
**
**			This is a state, triggered by State Machine
**			Second combo. Triggers attack2 animation
**          Waits a while and then sends to start finish state
*/

public class GroundComboState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        //Attack
        attackIndex = 2;
        duration = 0.5f;
        animator.SetTrigger("Attack" + attackIndex);
      //  Debug.Log("Player Attack " + attackIndex + " Fired!");
    }

    public override void OnUpdate(char type)
    {
        base.OnUpdate(type);

        if (fixedtime >= duration)
        {
            if (shouldCombo)
            {
                stateMachine.SetNextState(new GroundFinisherState());
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
    }
}
