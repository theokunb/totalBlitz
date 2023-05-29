public abstract class Condition
{
    public Condition(State targetState)
    {
        TargetState = targetState;
    }

    public State TargetState { get; private set; }

    public abstract bool CanTransit();
}
