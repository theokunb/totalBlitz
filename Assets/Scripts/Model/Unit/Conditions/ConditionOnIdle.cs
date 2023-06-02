public class ConditionOnIdle : Condition
{
    private Input _input;

    public ConditionOnIdle(State state, Input input): base(state)
    {
        _input = input;
        _input.Enable();
    }

    ~ConditionOnIdle() 
    {
        _input.Disable();
    }

    public override bool CanTransit()
    {
        var forward = _input.ForwardReadValue();
        var back = _input.BackReadValue();
        var left = _input.LeftReadValue();
        var right = _input.RightReadValue();

        return forward + back + left + right == 0;
    }
}
