public abstract class State
{
    protected readonly State Fsm;

    public State(State fsm)
    {
        Fsm = fsm;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
