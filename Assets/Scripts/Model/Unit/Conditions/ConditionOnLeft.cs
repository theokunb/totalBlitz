public class ConditionOnLeft : Condition
{
    private Input _input;

    public ConditionOnLeft(State state, Input input) : base(state)
    {
        _input = input;
        _input.Enable();
    }

    public override bool CanTransit()
    {
        return _input.LeftReadValue() > 0;
    }
}
