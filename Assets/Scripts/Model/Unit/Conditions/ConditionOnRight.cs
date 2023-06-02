public class ConditionOnRight : Condition
{
    private Input _input;

    public ConditionOnRight(State state, Input input) : base(state)
    {
        _input = input;
        _input.Enable();
    }

    ~ConditionOnRight()
    {
        _input.Disable();
    }

    public override bool CanTransit()
    {
        return _input.RightReadValue() != 0;
    }
}
