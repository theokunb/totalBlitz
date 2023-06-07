public class ConditionOnBack : Condition
{
    private Input _input;

    public ConditionOnBack(State state, Input input) : base(state)
    {
        _input = input;
        _input.Enable();
    }

    public override bool CanTransit()
    {
        return _input.BackReadValue() != 0;
    }
}
