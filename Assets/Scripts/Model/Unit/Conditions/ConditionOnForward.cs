public class ConditionOnForward : Condition
{
    private Input _input;

    public ConditionOnForward(State state, Input input) : base(state)
    {
        _input = input;
        _input.Enable();
    }

    public override bool CanTransit()
    {
        return _input.ForwardReadValue() != 0;
    }
}
