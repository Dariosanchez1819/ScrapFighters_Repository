using UnityEngine;

/*
**		State Machine
**
**			Keeps always 1 state running on Update.
*/

public class StateMachine : MonoBehaviour
{
	public string customName;

	public State mainStateType;

	public State CurrentState;
	public State nextState;
	public char		type;
	void Start()
	{
		OnValidate();
		
	}

	// Update is called once per frame
	void Update()
	{
		if (nextState != null)
		{
			SetState(nextState);
		}

		if (CurrentState != null)
			CurrentState.OnUpdate(type);
	}

	private void SetState(State _newState)
	{
		nextState = null;
		if (CurrentState != null)
		{
			CurrentState.OnExit();
		}
		CurrentState = _newState;
		CurrentState.OnEnter(this);
	}








	public void SetNextState(State _newState)
	{
		if (_newState != null)
		{
			nextState = _newState;
		}
	}

















	private void LateUpdate()
	{
		if (CurrentState != null)
			CurrentState.OnLateUpdate();
	}

	private void FixedUpdate()
	{
		if (CurrentState != null)
			CurrentState.OnFixedUpdate();
	}

	public void SetNextStateToMain()
	{
		nextState = mainStateType;
	}

	private void Awake()
	{
		SetNextStateToMain();
	}


	private void OnValidate()
	{
		if (mainStateType == null)
		{
			if (customName == "Combat")
			{
				mainStateType = new IdleCombatState();
			}
		}
	}
}