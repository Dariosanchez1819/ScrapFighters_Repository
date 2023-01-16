using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
**		Character Combo
**
**			This is a the opening for the trigger states
*/



public class CharacterCombo : MonoBehaviour
{
	private StateMachine meleeStateMachine;

	[SerializeField] public Collider2D			hitbox;
	[SerializeField] public GameObject			Hiteffect;

	public char									player_key;
    public GameObject							character;



	// Start is called before the first frame update
	void Start()
	{
		if (player_key == 'a')
			character =  GameObject.Find("Character_a");
		if (player_key == 'b')
			character =  GameObject.Find("Character_b");
		meleeStateMachine = GetComponent<StateMachine>();

		meleeStateMachine.CurrentState = new IdleCombatState();
	}

	// Update is called once per frame
	void Update()
	{
		if (pressing_attack() && meleeStateMachine.CurrentState.GetType() == typeof(IdleCombatState))
		{
			print("Penis");
			meleeStateMachine.SetNextState(new GroundEntryState());
		}

	}


	bool pressing_attack()
	{
		if ((player_key == 'a' && Input.GetKeyDown(KeyCode.B)) ||
			(player_key == 'b' && Input.GetMouseButtonDown(0))) 
		{
			character.GetComponent<Character>().attacking = true;
			return (true);
		}
		return (false);
	}

}
