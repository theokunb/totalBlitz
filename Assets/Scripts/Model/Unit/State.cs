public abstract class State
{
    protected readonly Fsm Fsm;

    public State(Fsm fsm)
    {
        Fsm = fsm;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
