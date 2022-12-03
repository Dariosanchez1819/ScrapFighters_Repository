using UnityEngine;

public abstract class State
{
    protected float time { get; set; }
    protected float fixedtime { get; set; }
    protected float latetime { get; set; }

    public StateMachine stateMachine;

    public virtual void OnEnter(StateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }


    public virtual void OnUpdate(char type)
    {
        time += Time.deltaTime;
    }

    public virtual void OnFixedUpdate()
    {
        fixedtime += Time.deltaTime;
    }
    public virtual void OnLateUpdate()
    {
        latetime += Time.deltaTime;
    }

    public virtual void OnExit()
    {

    }









    /// Removes a gameobject, component, or asset.
    protected static void Destroy(UnityEngine.Object obj)
    {
        UnityEngine.Object.Destroy(obj);
    }

    /// Returns the component of type T if the game object has one attached, null if it doesn't.
    protected T GetComponent<T>() where T : Component { return stateMachine.GetComponent<T>(); }

    /// Returns the component of Type <paramref name="type"/> if the game object has one attached, null if it doesn't.
    protected Component GetComponent(System.Type type) { return stateMachine.GetComponent(type); }

    /// Returns the component with name <paramref name="type"/> if the game object has one attached, null if it doesn't.
    protected Component GetComponent(string type) { return stateMachine.GetComponent(type); }
}