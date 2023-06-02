public class ConditionOnBack : Condition
{
    private Input _input;

    public ConditionOnBack(State state, Input input) : base(state)
    {
        _input = input;
        _input.Enable();
    }

    ~ConditionOnBack() 
    {
        _input.Disable();
    }

    public override bool CanTransit()
    {
        return _input.BackReadValue() != 0;
    }
}
