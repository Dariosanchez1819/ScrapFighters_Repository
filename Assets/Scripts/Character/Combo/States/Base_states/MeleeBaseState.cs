using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBaseState : State
{
	// How long this state should be active for before moving on
	public float duration;
	protected Animator animator;
	// bool to check whether or not the next attack in the sequence should be played or not
	protected bool shouldCombo;
	// The attack index in the sequence of attacks
	protected int attackIndex;



	protected Collider2D hitCollider;

	private float AttackPressedTimer = 0;

	public override void OnEnter(StateMachine _stateMachine)
	{
		base.OnEnter(_stateMachine);
		animator = GetComponent<Animator>();
		hitCollider = GetComponent<CharacterCombo>().hitbox;
	}






	public override void OnUpdate(char type)
	{
		base.OnUpdate('a'); //this does nothign
		AttackPressedTimer -= Time.deltaTime;

		if (animator.GetFloat("Weapon.Active") > 0f)
		{
			//Attack();
		}
		if ((type == 'B' && Input.GetMouseButtonDown(0)) || (type == 'A' && Input.GetKeyDown(KeyCode.B)))
		{
			AttackPressedTimer = 2;
		}
		if (animator.GetFloat("AttackWindow.Open") > 0f && AttackPressedTimer > 0)
		{
			shouldCombo = true;
		}
	}







	public override void OnExit()
	{
		base.OnExit();
	}
}
